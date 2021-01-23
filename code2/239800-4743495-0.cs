    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace test1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            //declate private varliables
            int parameter1;
            string parameter2;
    
            private void button1_Click(object sender, EventArgs e)
            {
                // create form
                Form2 form2 = new Form2();
                if (form2.ShowDialog(this) == DialogResult.OK)
                {
                    // if the button is pressed
                    parameter1 = form2.Parameter1;
                    parameter2 = form2.Parameter2;
                }        
            }
        }
    }
