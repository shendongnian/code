    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class MyPictureBox : PictureBox {
        private object locker = new object();
        public new Image Image {
            get { return base.Image; }
            set { lock (locker) { base.Image = value; } }
        }
        public Image Clone() {
            lock (locker) {
                return (this.Image != null) ? (Image)this.Image.Clone() : null;
            }
        }
        protected override void OnPaint(PaintEventArgs pe) {
            lock (locker) {
                base.OnPaint(pe);
            }
        }
    }
