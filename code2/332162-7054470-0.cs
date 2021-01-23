    public LinearGradientBrush GetValueColor(decimal value)
    {
        LinearGradientBrush brush = new LinearGradientBrush();
        byte[] byteArray = StringToByteArray(value.ToString());
        for (int i = 0; i < byteArray.Length; i += 3)
        {
            byte red = byteArray[i];
            byte green = i < byteArray.Length - 1 ? byteArray[i + 1] : (byte)0;
            byte blue = i < byteArray.Length - 2 ? byteArray[i + 2] : (byte)0;
            brush.GradientStops.Add(
                new GradientStop(new Color {A = 255, R = red, G = green, B = blue },
                                                (double)(i+1) / byteArray.Length));
        }
        return brush;
    }
