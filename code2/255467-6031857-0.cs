    /// <summary>
    /// Calculates the Screen Dots Per Inch of a Display Monitor
    /// </summary>
    /// <param name="monitorSize">Size, in inches</param>
    /// <param name="resolutionWidth">width resolution, in pixels</param>
    /// <param name="resolutionHeight">height resolution, in pixels</param>
    /// <returns>double presision value indicating the Screen Dots Per Inch</returns>
    public static double ScreenDPI(int monitorSize, int resolutionWidth, int resolutionHeight) {
      //int resolutionWidth = 1600;
      //int resolutionHeight = 1200;
      //int monitorSize = 19;
      if (0 < monitorSize) {
        double screenDpi = Math.Sqrt(Math.Pow(resolutionWidth, 2) + Math.Pow(resolutionHeight, 2)) / monitorSize;
        return screenDpi;
      }
      return 0;
    }
