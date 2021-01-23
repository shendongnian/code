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
                if (value == null) this.AutoScrollMinSize = new Size(0, 0);
                else {
                    var size = value.Size;
                    using (var gr = this.CreateGraphics()) {
                        size.Width = (int)(size.Width * gr.DpiX / value.HorizontalResolution);
                        size.Height = (int)(size.Height * gr.DpiY / value.VerticalResolution);
                    }
                    this.AutoScrollMinSize = size;
                }
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            if (mImage != null) e.Graphics.DrawImage(mImage, 0, 0);
            base.OnPaint(e);
        }
    }
