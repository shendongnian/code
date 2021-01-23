    using System;
    using System.Windows.Forms;
    
        namespace AppSettings {
            public partial class Form1 : Form {
                public Form1() {
                    InitializeComponent();
                }
        
                private void Form1_Load(object sender, EventArgs e) {
                    textBox1.Text = Properties.Settings.Default.tbText;
                }
            }
        }
