    if (e.Column == 1 && e.Row == 0)
    {
        var rectangle = e.CellBounds;
        rectangle.Inflate(-1, -1);
                
        ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.All); // 3D border
        ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Red, ButtonBorderStyle.Dotted); // dotted border
    }
