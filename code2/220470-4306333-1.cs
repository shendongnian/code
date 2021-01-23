    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class ImageBox : Panel {
        public ImageBox() {
            this.AutoScroll = true;
            this.DoubleBuffered = true;
        }
        private Image mImage;
        public Image Image {
            get { return mImage; }
            set {
                mImage = value;
                if (mImage != null) this.AutoScrollMinSize = mImage.Size;
                else this.AutoScrollMinSize = new Size(0, 0);
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            if (mImage != null) e.Graphics.DrawImage(mImage, 0, 0);
            base.OnPaint(e);
        }
    }
