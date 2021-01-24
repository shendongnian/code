    public static SolidColorBrush GetColorFromHex(string hexaColor)
            {
                return new SolidColorBrush(
                    Color.FromArgb(
                      Convert.ToByte(hexaColor.Substring(1, 2), 16),
                        Convert.ToByte(hexaColor.Substring(3, 2), 16),
                        Convert.ToByte(hexaColor.Substring(5, 2), 16),
                        Convert.ToByte(hexaColor.Substring(7, 2), 16)
                    )
                );
            }
