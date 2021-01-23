    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    class VerticalLabel : Label {
        private SizeF mSize;
        public VerticalLabel() {
            base.AutoSize = false;
        }
        [Browsable(false)]
        public override bool AutoSize {
            get { return false; }
            set { base.AutoSize = false; }
    	}
        public override string Text {
            get { return base.Text; }
            set { base.Text = value; calculateSize(); }
        }
        public override Font Font {
            get { return base.Font; }
            set { base.Font = value; calculateSize(); }
        }
        protected override void OnPaint(PaintEventArgs e) {
            using (var br = new SolidBrush(this.ForeColor)) {
                e.Graphics.RotateTransform(-90);
                e.Graphics.DrawString(Text, Font, br, -mSize.Width, 0);
            }
        }
        private void calculateSize() {
            using (var gr = this.CreateGraphics()) {
                mSize = gr.MeasureString(this.Text, this.Font);
                this.Size = new Size((int)mSize.Height, (int)mSize.Width);
            }
        }
    }
