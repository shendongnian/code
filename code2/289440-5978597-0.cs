    [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
    public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);
    public enum DeviceCap
    {
      /// <summary>
      /// Logical pixels inch in X
      /// </summary>
      LOGPIXELSX = 88,
      /// <summary>
      /// Logical pixels inch in Y
      /// </summary>
      LOGPIXELSY = 90
      // Other constants may be founded on pinvoke.net
    }      
