    using System.Drawing;
    using System.Windows.Forms;
    namespace EriaSDK.FormTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red, 1), new Rectangle(0, 0, 200, 200));
            }
        }
    }
