    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            public Form1() 
            { 
                InitializeComponent();
    
                FormClosed += Form_Helper.Generic_FormClosed;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 SecondaryForm = new Form2();
                SecondaryForm.FormClosed += Form_Helper.Generic_FormClosed;
                SecondaryForm.Show();
            }
        }
    }
