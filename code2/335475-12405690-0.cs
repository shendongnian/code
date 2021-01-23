      const string CLASS_LISTVIEW = "LISTVIEW";
      const int LVP_LISTGROUP = 2;
      [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
      private extern static int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, IntPtr pClipRect);
      public static void DrawWindowBackground(IntPtr hWnd, Graphics g, Rectangle bounds)
      {
        IntPtr theme = OpenThemeData(hWnd, CLASS_LISTVIEW);
        if (theme != IntPtr.Zero)
        {
          IntPtr hdc = g.GetHdc();
          RECT area = new RECT(bounds);
          DrawThemeBackground(theme, hdc, LVP_LISTGROUP, 0, ref area, IntPtr.Zero);
          g.ReleaseHdc();
          CloseThemeData(theme);
        }
      }
