    System.Drawing.Color MyColor = System.Drawing.Color.Red;
    System.Windows.Media.Color = ConvertColorType(MyColor);
    System.Windows.Media.Color ConvertColorType(System.Drawing.Color color)
    {
      byte AVal = color.A;
      byte RVal = color.R;
      byte GVal = color.G;
      byte BVal = color.B;
      return System.Media.Color.FromArgb(AVal, RVal, GVal, BVal);
    }
