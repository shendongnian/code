    public partial class UserControl1 : UserControl {
        public UserControl1() {
            InitializeComponent();
            paths = new List<GraphicsPath>();
            GraphicsPath example = new GraphicsPath();
            example.AddEllipse(new Rectangle(10, 10, 50, 30));
            paths.Add(example);
        }
        List<GraphicsPath> paths;
        protected override void OnPaint(PaintEventArgs e) {
            foreach (var path in paths) e.Graphics.FillPath(Brushes.Blue, path);
            base.OnPaint(e);
        }
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            // Trap WM_NCHITTEST on the client area
            if (m.Msg == 0x84 && m.Result == (IntPtr)1) {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                bool oncurve = false;
                foreach (var path in paths)
                    if (path.IsVisible(pos)) oncurve = true;
                if (!oncurve) m.Result = (IntPtr)(-1);  // HTTRANSPARENT
            }
        }
    }
