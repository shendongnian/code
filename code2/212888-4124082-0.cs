    Function RGBToHSB(rgb As RGBColor) As HSBColor
      Dim c As Color = Color.FromArgb(rgb.Red, rgb.Green, rgb.Blue)
      RGBToHSB.Hue = c.GetHue()
      RGBToHSB.Saturation = c.GetSaturation()
      RGBToHSB.Brightness = c.GetBrightness()
    End Function
