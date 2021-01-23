    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
        }
        private class MyRenderer : ToolStripProfessionalRenderer {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
                if (e.Item.Selected) {
                    e.Graphics.FillRectangle(Brushes.Bisque, e.Item.Bounds);
                }
                else base.OnRenderMenuItemBackground(e);
            }
        }
    }
