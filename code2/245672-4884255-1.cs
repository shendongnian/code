    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            }  
            void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if(listBox1.SelectedIndex == -1)
                {
                    Application.Exit();
                }
                //Rest of the code goes here.
            }
        }
    }
