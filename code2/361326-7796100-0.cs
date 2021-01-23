    public Form1() {
      InitializeComponent();
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
    }
    protected override void OnPaintBackground(PaintEventArgs e) {
      e.Graphics.Clear(SystemColors.Control);
      using (Pen setupDimGrayPen = new Pen(Color.DimGray, 5)) {
        Rectangle newRectangle;
        newRectangle = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
        e.Graphics.DrawRectangle(setupDimGrayPen, newRectangle);
      }
    }
