    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var p = GetTemplateChild("Glyph") as Path;
        if (null == p) return;
        var x = p.Width/2;
        var y = p.Height/2;
        var r = Math.Min(x, y) - 1;
        var e = new EllipseGeometry(new Point(x,y), r, r);
        // this is just a flattened dot, of course you can draw
        // something else, e.g. a star? ;)
        p.Data = e.GetFlattenedPathGeometry();
    }
