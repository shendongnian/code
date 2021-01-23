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
            TextBox textbox1 = new TextBox(), textbox2 = new TextBox();
            Button button1 = new Button();
            int FocusedTextBox = 0;
    
            public Form1()
            {
                InitializeComponent();
                this.Load += new System.EventHandler(this.Form1_Load);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
                button1.Click += new EventHandler(button1_Click);
    
                textbox1.Text = textbox2.Text = "1";
                textbox1.Location = new Point(100, 100);
                textbox2.Location = new Point(100, 140);
                button1.Location = new Point(100, 180);
    
                textbox1.Click += new EventHandler(textbox1_Click);
                textbox2.Click += new EventHandler(textbox2_Click);
                textbox1.ReadOnly = true;
                textbox2.ReadOnly = true;
    
                this.Controls.Add(textbox1);
                this.Controls.Add(textbox2);
                this.Controls.Add(button1);
            }
    
            void textbox2_Click(object sender, EventArgs e)
            {
                FocusedTextBox = 2;
            }
    
            void textbox1_Click(object sender, EventArgs e)
            {
                FocusedTextBox = 1;
            }
    
            void button1_Click(object sender, EventArgs e)
            {
                if (FocusedTextBox ==1)
                    textbox1.Text = (int.Parse(textbox1.Text) + 1).ToString();
                else if (FocusedTextBox == 2)
                    textbox2.Text = (int.Parse(textbox2.Text) + 1).ToString();
            }
        }
    }
