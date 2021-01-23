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
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
                //enable timer1 here or in designer
                timer1.Enabled = true;
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                //disable timer1 first thing, otherwise it can end up ticking
                //multiple times before you've had a chance to disable it
                //if the timespan is really short
                timer1.Enabled = false;
                int d;
    
                for (d = 0; d <= 100; d++)
                    progressBar1.Value = d;
    
                Hide();
                //create a new Form1 and then show it
                new Form1().Show();
            }
        }
    }
