    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Bitmap bm = new Bitmap(textBox1.Width,textBox1.Height);
                textBox1.DrawToBitmap(bm,new Rectangle(0,0,bm.Width,bm.Height));
                bm.Save("image.bmp");
            }
        }
    }
