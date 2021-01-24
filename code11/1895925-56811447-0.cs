    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    [DesignerCategory("code")]
    public class PayceButton : Button
    {
        private Image myImage = null;
        private float borderWidth = 6.0F;
        public PayceButton() => InitializeComponent();
        private void InitializeComponent()
        {
            this.myImage = Properties.[A Resource Image Name];
            this.BackColor = Color.FromArgb(88, 88, 88);
        }
        public float BorderWidth {
            get => borderWidth;
            set { borderWidth = value; this.Invalidate(); }
        }
        public override string Text {
            get => string.Empty;
            set => base.Text = string.Empty;
        }
        public new Image Image {
            get => this.myImage;
            set { this.myImage?.Dispose();
                  this.myImage = value;
                  Invalidate();
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage {
            get => base.BackgroundImage;
            set => base.BackgroundImage = null;
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout {
            get => base.BackgroundImageLayout;
            set => base.BackgroundImageLayout = ImageLayout.None;
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            DrawPayceImage(e.Graphics);
        }
        private void DrawPayceImage(Graphics g)
        {
            float scale = (Math.Min(this.Height, this.Width) - (borderWidth * 4)) / 
                           Math.Min(myImage.Height, myImage.Width);
            var scaledImageSize = new SizeF(this.myImage.Width * scale, myImage.Height * scale);
            var imageLocation = new PointF((this.Width - scaledImageSize.Width) / 2,
                                           (this.Height - scaledImageSize.Height) /2);
            g.DrawImage(myImage,
                new RectangleF(imageLocation, scaledImageSize),
                new RectangleF(PointF.Empty, myImage.Size), GraphicsUnit.Pixel);
        }
        protected override void OnHandleDestroyed(EventArgs e) {
            this.myImage?.Dispose();
            base.OnHandleDestroyed(e);
        }
        protected override void Dispose(bool disposing) {
            if (disposing) { this.myImage?.Dispose(); }
            base.Dispose(disposing);
        }
    }
