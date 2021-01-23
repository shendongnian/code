    private static readonly Geometry RadioDot = Geometry.Parse("M9,5.5L8.7,7.1 7.8,8.3 6.6,9.2L5,9.5L3.4,9.2 2.2,8.3 1.3,7.1L1,5.5L1.3,3.9 2.2,2.7 3.4,1.8L5,1.5L6.6,1.8 7.8,2.7 8.7,3.9L9,5.5z");
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var p = GetTemplateChild("Glyph") as Path;
        if (null == p) return;
        p.Data = RadioDot;
    }
