    public string GenerateRgba(string backgroundColor, decimal backgroundOpacity)
    {
     Color color = ColorTranslator.FromHtml(hexBackgroundColor);
     int r = Convert.ToInt16(color.R);
     int g = Convert.ToInt16(color.G);
     int b = Convert.ToInt16(color.B);
     return string.Format("rgba({0}, {1}, {2}, {3});", r, g, b, backgroundOpacity);
    }
