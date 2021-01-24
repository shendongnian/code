    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string stextBox1 = textBox1.Text;
    
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                textBox1.Text = regex.Replace(stextBox1, " ");
            }
        }
    }
