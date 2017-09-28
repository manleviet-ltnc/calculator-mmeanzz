﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculatorapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isTypingNumber = false;

        enum PhepToan { None, Cong, Tru, Nhan, Chia};
        PhepToan pheptoan;

        double nho;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NhapSo(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            NhapSo(btn.Text);
        }

        private void NhapSo(string so)
        {
            if (isTypingNumber)
                lblHienThi.Text = lblHienThi.Text + so;
            else
            {
                lblHienThi.Text = so;
                isTypingNumber = true;
            }
        }
       
        private void NhapPhepToan(object sender, EventArgs e)
        {
            if (nho != 0)
                TinhKetQua();

            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+": pheptoan = PhepToan.Cong; break;
                case "-": pheptoan = PhepToan.Tru; break;
                case "*": pheptoan = PhepToan.Nhan; break;
                case "/": pheptoan = PhepToan.Chia; break;
            }

            nho = double.Parse(lblHienThi.Text);

            isTypingNumber = false;
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTypingNumber = false;
            nho = 0;
            pheptoan = PhepToan.None;
        }

        private void TinhKetQua()
        {
            //tinh toan dua tren: nho, lblHienThi.Text
            double tam = double.Parse(lblHienThi.Text);
            double ketqua = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: ketqua = nho + tam; break;
                case PhepToan.Tru: ketqua = nho - tam; break;
                case PhepToan.Nhan: ketqua = nho * tam; break;
                case PhepToan.Chia: ketqua = nho / tam; break;
            }

            //gan ket qua tinh duoc len lblHienThi
            lblHienThi.Text = ketqua.ToString();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    NhapSo("" + e.KeyChar);
                    break;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lblHienThi.Text.Length > 1)
                lblHienThi.Text = lblHienThi.Text.Remove(lblHienThi.Text.Length - 1, 1);
            else lblHienThi.Text = 0.ToString();
                   
        }

        private void btnDoiDau_Click(object sender, EventArgs e)
        {
            lblHienThi.Text = (-1 * (double.Parse(lblHienThi.Text))).ToString();
        }

        private void btnNho_Click(object sender, EventArgs e)
        {
          
            lblHienThi.Text = 0.ToString();
        }

        private void btnPhanTram_Click(object sender, EventArgs e)
        {
            lblHienThi.Text = ((double.Parse(lblHienThi.Text) / 100)).ToString();
        }

        private void btnCan_Click(object sender, EventArgs e)
        {            
            lblHienThi.Text = (Math.Sqrt(Double.Parse(lblHienThi.Text))).ToString();
        }
    }

}
