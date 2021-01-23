    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
     
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
     
            private void btndeletevowel_Click(object sender, EventArgs e)
            {
                string s1;
                string s2;
                s1 = textBox1.Text;
                s2 = System.Text.RegularExpressions.Regex.Replace(s1, "[aeiouAEIOU]", "");
                MessageBox.Show(s2);
            }
           
            }
        }
     
