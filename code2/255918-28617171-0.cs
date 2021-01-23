    public partial class TurnButton : Button
    {
        public TurnButton()
        {
            InitializeComponent();
        }
        int angle = 0;   // current rotation
        Point oMid;      // original center
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (oMid == Point.Empty) oMid = new Point(Left + Width / 2, Top + Height / 2);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
           int mx = this.Size.Width / 2;
           int my = this.Size.Height / 2;
           SizeF size = pe.Graphics.MeasureString(Text, Font);
           string t_ = Text;
           Text = "";
            base.OnPaint(pe);
            if (!this.DesignMode)
            {
                Text = t_; pe.Graphics.TranslateTransform(mx, my);
                pe.Graphics.RotateTransform(angle);
                pe.Graphics.TranslateTransform(-mx, -my);
                pe.Graphics.DrawString(Text, Font, SystemBrushes.ControlText,
                                      mx - (int)size.Width / 2, my - (int)size.Height / 2);
            }
        }
        protected override void OnClick(EventArgs e)
        {
            this.Size = new Size(Height, Width);
            this.Location = new Point(oMid.X - Width / 2, oMid.Y - Height / 2);
            angle = (angle + 90) % 360;
            Text = angle + "°";
            base.OnClick(e);
        }
    }
