    ... .ctor()
    {
        ...
        // indicate user will paint
        SetStyle(ControlStyles.UserPaint, true);
        // rest is optional if you want/need it
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);   
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        SetStyle(ControlStyles.Opaque, true);
    }
    protected override void OnPaint(PaintEventArgs p)
    {
        // depending on how you set the control styles, you might need
        // this to draw the background of your control wit a call to the methods base
        base.OnPaint(p);
        Graphics g = p.Graphics;
        // ... Do your painting here with g ....
    }
