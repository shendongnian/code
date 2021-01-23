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
        public partial class Form2 : Form
        {        
            public Form2()
            {
                InitializeComponent();
            }
    
            //declate internal parameters
            internal int Parameter1 { get; private set; }
            internal string Parameter2 { get; private set; }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // if the button is pressed
                Form1 form1 = this.Owner as Form1;
                if (form1 != null) 
                {
                    // sets the local parameters
                    Parameter1 = -1;
                    Parameter2 = "John Doe";
    
                    this.DialogResult = DialogResult.OK;
                    
                    Close();
                }
            }
        }
    }
