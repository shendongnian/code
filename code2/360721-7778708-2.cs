    using System.Drawing;
    using System.Drawing.Drawing2D;
    public Form1() {
      InitializeComponent();
      this.DoubleBuffered = true;
      this.ResizeRedraw = true;
    }
    protected override void OnPaintBackground(PaintEventArgs e) {
      using (var lgb = new LinearGradientBrush(this.ClientRectangle, Color.Yellow, Color.Green, LinearGradientMode.Vertical))
        e.Graphics.FillRectangle(lgb, this.ClientRectangle);
    }
