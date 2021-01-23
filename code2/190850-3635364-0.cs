    Viewbox v = new Viewbox();
    v.Child = uielem;
    uielem.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    v.Measure(uielem.DesiredSize);
    v.Arrange(new Rect(new Point(), uielem.DesiredSize));
    v.UpdateLayout();
    r.Render(v);
