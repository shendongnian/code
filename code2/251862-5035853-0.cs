    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            int i = 1;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                flowLayoutPanel1.Controls.Add(new Button {Text=string.Format("Button {0}", i) });
                i += 1;
            }
        }
    }
