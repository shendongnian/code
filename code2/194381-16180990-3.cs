    public partial class Form1 : Form {
        public Form1() {
            var strip = new ToolStrip();
            test = new ToolStripControlHost(new TextBox());
            strip.Items.Add(test);
            this.Controls.Add(strip);
        }
        protected override void OnMouseClick(MouseEventArgs e) {
            test.Dispose();
            test.Visible = true;
        }
        ToolStripItem test;
    }
