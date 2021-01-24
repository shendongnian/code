    using System;
    using System.Windows.Forms;
    
    namespace WindowsTestForms
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //Clipboard.SetText("Testing...");
                this.FormClosing += Form1_FormClosing;
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                //Clipboard.SetText(" "); // Value cannot be null
                Clipboard.Clear();
            }
        }
    }
