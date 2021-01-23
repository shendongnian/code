    byte r = 1, g = 203, b = 103; // input color
    double minDist = double.MaxValue;
    short match = 0; // this will end up with our answer
    for (short i = 1; i <= 255; ++i)
    {
        var color = Autodesk.AutoCAD.Colors.Color.FromColorIndex(ColorMethod.ByAci, i);
        System.Drawing.Color rgb = color.ColorValue;
        double dist =
            Math.Pow(r - rgb.R, 2) +
            Math.Pow(g - rgb.G, 2) +
            Math.Pow(b - rgb.B, 2);
        if (dist < minDist)
        {
            minDist = dist;
            match = i;
        }
    }
