    string formatString = r.NumberFormat;
    Regex colorRegExp = new Regex(@"^\[(?<color>\S+)\]", RegexOptions.Compiled);
    Color resultColor;
    System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(new Color());
    Match m = colorRegExp .Match(formatString);
    if (true == m.Success)
    {
       string colorString = m.Groups["color"].Value;
       resultColor = (Color)converter.ConvertFromString(colorString);
    }
