    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    
    namespace part_B_19
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    StreamReader sr = new StreamReader(@"C:\Users\Acer\Documents\Visual Studio 2012\Projects\combobox.txt");
                    string line = sr.ReadLine();
    
                    while (line != null)
                    {
                        comboBox1.Items.Add(line);
                        line = sr.ReadLine();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                
            }
        }
    }
