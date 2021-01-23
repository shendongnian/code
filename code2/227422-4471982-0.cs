    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class MyTextBox : TextBox {
        private Label label;
        public MyTextBox() {
            label = new Label();
            label.AutoSize = true;
            label.Font = this.Font;
            label.Location = this.Location;
            label.Resize += new EventHandler(label_Resize);
        }
        protected override void OnParentChanged(EventArgs e) {
            // Keeps label on the same parent as the text box
            base.OnParentChanged(e);
            label.Parent = this.Parent;   // NOTE: no dispose necessary
        }
    
        private void moveLabel() {
            // Keep label right-aligned to the left of the text box
            label.Location = new Point(this.Left - label.Width - 10, this.Top);
        }
        private void label_Resize(object sender, EventArgs e) {
            moveLabel();
        }
        protected override void OnLocationChanged(EventArgs e) {
            base.OnLocationChanged(e);
            moveLabel();
        }
    
        public string Description {
            get { return label.Text; }
            set { label.Text = value; }
        }
    
        public override Font Font {
            get { return base.Font; }
            set { base.Font = label.Font = value; }
        }
    
    }
