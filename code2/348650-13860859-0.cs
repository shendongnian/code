    using System;
    using System.Windows.Forms;
    
    namespace TestTextBoxAccessViolation {
        public partial class Form1 : Form {
    
            
            public Form1() {
                InitializeComponent();
            }
    
            private void Form1_DragEnter(object sender, DragEventArgs e) {
                e.Effect = DragDropEffects.Copy;
            }
    
            private void Form1_DragDrop(object sender, DragEventArgs e) {
                e.Data.GetData("DragImageBits");
                Form1 f = new Form1();
                f.textBox1.Text = "Keep resizing this window and you'll get an AccessViolationException after a while";
                f.Show();
            }
        }
    }
