    class DoubleBufferedPanel : Panel {
        public DoubleBufferedPanel() : base() {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.DoubleBuffered |
                          ControlStyles.Opaque |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }
        public override void OnPaint(PaintEventArgs e) {
            // Do your painting *here* instead, and don't call the base method.
        }
        // Override OnMouseMove, etc. here as well.
    }
