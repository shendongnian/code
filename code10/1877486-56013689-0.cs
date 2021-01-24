    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btn_click(object sender, EventArgs e)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
    
                Button btn = sender as Button;
                if (btn != null)
                {
                    btn.Enabled = false;
                }
            }
        }
    }
