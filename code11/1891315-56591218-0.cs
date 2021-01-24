    using System;
    using System.IO;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.textBox1.Text = File.ReadAllText(@"F:\Example");
            }
        }
    }
