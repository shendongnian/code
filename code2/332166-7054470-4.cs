    public decimal GetColorValue(LinearGradientBrush brush)
    {
        List<byte> byteList = new List<byte>();
        foreach (GradientStop gradientStop in brush.GradientStops)
        {
            byteList.Add(gradientStop.Color.R);
            byteList.Add(gradientStop.Color.G);
            byteList.Add(gradientStop.Color.B);
        }
        return Convert.ToDecimal(Encoding.ASCII.GetString(byteList.ToArray()));
    }
