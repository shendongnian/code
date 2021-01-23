    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class MyLabel : Label {
        public MyLabel() {
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleRight;
        }
        public new Image Image {
            get { return base.Image; }
            set {
                base.Image = value;
                if (this.AutoSize) {  // Force size calculation
                    this.AutoSize = false;
                    this.AutoSize = true;
                }
            }
        }
        public override Size GetPreferredSize(Size proposedSize) {
            var size = base.GetPreferredSize(proposedSize);
            if (this.Image != null) size = new Size(size.Width + 3 + Image.Width, size.Height);
            return size;
        }
    }
