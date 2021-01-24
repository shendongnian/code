    namespace xp_11_test_3
    {
    public partial class asiwindow : Form
    {
        float angle = 15 * 1.59f;
        float aspd = 15;
        public asiwindow()
        {
            InitializeComponent();
        }
        private void asiwindow_Load(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
        }
        public void updatereqd()
        {
            //label1.Text = "tried to update";
              aspd = float.Parse(Form1.airspeed);
              pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (Bitmap needle = new Bitmap(xp_11_test_3.Properties.Resources.needle_2))
            {
                try
                {
                    //aspd = (int.Parse(textBox1.Text));
                    if (aspd < 15) { aspd = 15; }
                    if (aspd > 200) { aspd = 200; }
                    angle = (aspd * 1.59f) - 7.95f;
                }
                catch { }
                //label1.Text = angle.ToString("###0°");
                // this is the offset after the translation
                Point targetPoint = new Point(-needle.Width / 2, needle.Height / 2 - needle.Height);
                // shortcuts for the sizes
                Size nSize = needle.Size;
                Size pSize = pictureBox1.ClientSize;
                // this is the translation of the graphic to meet the rotation point
                int transX = pSize.Width / 2;
                int transY = pSize.Height / 2;
                //set the rotation point and rotate
                e.Graphics.TranslateTransform(transX, transY);
                e.Graphics.RotateTransform(angle);
                // draw on the rotated graphics
                e.Graphics.DrawImage(needle, targetPoint);
            }
        }
    }
}
