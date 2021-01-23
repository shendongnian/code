    public static ColorExtensions {
    
      public static Color ToGrayscale(this int brightness) {
        return Color.FromArgb(brightness, brightness, brightness);
      }
    
    }
