    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
                Regex r = new Regex(@"(?<=\<\w+)[#\{\}\(\)\&](?=\>)|(?<=\</\w+)[#\{\}\(\)\&](?=\>)");
                textBox2.Text = r.Replace(textBox1.Text, new MatchEvaluator(deleteMatch));
            }
    
            string deleteMatch(Match m) { return ""; }
        }
    }
