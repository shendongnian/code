    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private Image mImage;
        protected override void OnPaint(PaintEventArgs e) {
            if (mImage != null) e.Graphics.DrawImage(mImage, Point.Empty);
            base.OnPaint(e);
        }
        private void button1_Click(object sender, EventArgs e) {
            using (var srce = Image.FromFile(@"c:\temp\grayscale.png")) {
                if (mImage != null) mImage.Dispose();
                mImage = new Bitmap(srce.Width, srce.Height);
                float[][] coeff = {
                                new float[] { 1, 0, 0, 0, 0 },
                                new float[] { 0, 1, 0, 0, 0 },
                                new float[] { 0, 0, 0, 0, 0 },
                                new float[] { 0, 0, 0, 1, 0 },
                                new float[] { 0, 0, 1, 0, 1 }};
                ColorMatrix cm = new ColorMatrix(coeff);
                var ia = new ImageAttributes();
                ia.SetColorMatrix(new ColorMatrix(coeff));
                using (var gr = Graphics.FromImage(mImage)) {
                    gr.DrawImage(srce, new Rectangle(0, 0, mImage.Width, mImage.Height),
                        0, 0, mImage.Width, mImage.Height, GraphicsUnit.Pixel, ia);
                }
            }
            this.Invalidate();
        }
    }
