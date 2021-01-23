    public MyTransparentControl()
    {
        SetStyle( ControlStyles.SupportsTransparentBackColor |     
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true );
        BackColor = Color.Transparent;
    }
