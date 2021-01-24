      public  class MyPanel : Panel
        {
            private Color colorBorder = Color.Transparent;
    
    
            public MyPanel()
                : base()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
    
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.DrawRectangle(
                    new Pen(
                        new SolidBrush(colorBorder), 6),
                        e.ClipRectangle);
            }
    
            public Color BorderColor
            {
                get
                {
                    return colorBorder;
                }
                set
                {
                    colorBorder = value;
                }
            }
        }
