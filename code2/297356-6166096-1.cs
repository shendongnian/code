    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                someMethod(pictureBox1);
            }
    
            private void someMethod(PictureBox p)
            {
                p.BackColor = Color.Blue;
                // this is an example of pictureBox being passed as 
                // a paramter to this method
            }
        }
    }
