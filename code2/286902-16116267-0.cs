    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (radioButton1.Checked == true)
                    prime_not();
                else
                    binary();
            }
    
         
    
            private void binary()
            {
                label1.Text = Convert.ToString(Convert.ToInt64(textBox1.Text), 2);
            }
    
            private void prime_not()
            {
                if (Convert.ToInt16(textBox1.Text) % 2 == 0)
                    label1.Text= "Not Prime";
                else
                    label1.Text = "Prime";
            }
    
            private void label1_Click(object sender, EventArgs e)
            {
    
            }
    
            private void label1_Click_1(object sender, EventArgs e)
            {
    
            }
    
        }
    }
