    RadialGradientBrush b = new RadialGradientBrush();
    b.GradientOrigin = new Point(0.5, 0.5);
    b.Center = new Point(0.5, 0.5);
    b.RadiusX = 0.5;
    b.RadiusY = 0.5;
    b.GradientStops.Add(new GradientStop(Colors.Transparent,0));
    b.GradientStops.Add(new GradientStop(Colors.Transparent,0.25));
    b.GradientStops.Add(new GradientStop(Colors.Tomato, 0.25));
    g.FillEllipse(b, 50, 50, 200, 200);
