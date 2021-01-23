    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Form1Form2
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            Form1 _f1 = null;
            public Form2(Form1 f) : this()
            {
                _f1 = f;
            }
    
    
            private void button1_Click(object sender, EventArgs e)
            {
                _f1.Text = "Nice!";
            }
        }
    }
