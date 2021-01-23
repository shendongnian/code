    public partial class FormPictureboxPaint : Form
    {
      private Bitmap m_oBitmap;
      public FormPictureboxPaint ()
      {
        InitializeComponent ();
        string sFile = Application.StartupPath + @"\..\..\..\bitmap.png";  // The bitmap file contains an image with 10k x 10k pixels.
        m_oBitmap = new Bitmap (sFile);
        if (false)  // CHANGE TO TRUE IF TESTING WITH 1k x 1k BITMAPS
        {
          var oBitmap = new Bitmap (m_oBitmap, new Size (1000, 1000));
          m_oBitmap.Dispose ();
          m_oBitmap = null;
          GC.Collect ();
          GC.WaitForFullGCComplete ();
          GC.WaitForPendingFinalizers ();
          m_oBitmap = oBitmap;
        }
      }
      private void pictureBox1_Paint (object sender, PaintEventArgs e)
      {
        var oGraphics = e.Graphics;
        DateTime dtNow = DateTime.Now;
        // UNCOMMENT THE FOLLOWING LINES FOR TESTS WITH DrawImage
        // COMMENT THE FOLLOWING LINES FOR TESTS WITH GDI
        //for (int ixCnt = 0; ixCnt < 1000; ixCnt++)
        //  PictureboxPaint01 (oGraphics);
        // COMMENT THE FOLLOWING LINES FOR TESTS WITH DrawImage
        // UNCOMMENT THE FOLLOWING LINES FOR TESTS WITH GDI
        for (int ixCnt = 0; ixCnt < 100; ixCnt++)
          PictureboxPaint02 (oGraphics);
        TimeSpan ts = (DateTime.Now - dtNow);
      }
      private void PictureboxPaint01 (Graphics i_oGraphics)
      {
        //_oGraphics.DrawImage (m_oBitmap, new Point ());
        i_oGraphics.DrawImage (m_oBitmap, new Rectangle (0, 0, 1000, 1000));
      }
      private void PictureboxPaint02 (Graphics i_oGraphics)
      {
        // from https://stackoverflow.com/a/7481071
        i_oGraphics.GdiDrawImage
        (
            m_oBitmap,
            new Rectangle (
                (int)pictureBox1.Left,
                (int)pictureBox1.Top,
                (int)pictureBox1.Width,
                (int)pictureBox1.Height
            ),
            0, 0, m_oBitmap.Width, m_oBitmap.Height
        );
      }
    }
    public static class GraphicsHelper
    {
      public static void GdiDrawImage (this Graphics graphics, Bitmap image, Rectangle rectangleDst, int nXSrc, int nYSrc, int nWidth, int nHeight)
      {
        IntPtr hdc = graphics.GetHdc ();
        IntPtr memdc = GdiInterop.CreateCompatibleDC (hdc);
        IntPtr bmp = image.GetHbitmap ();
        GdiInterop.SelectObject (memdc, bmp);
        GdiInterop.SetStretchBltMode (hdc, 0x04);
        GdiInterop.StretchBlt (hdc, rectangleDst.Left, rectangleDst.Top, rectangleDst.Width, rectangleDst.Height, memdc, nXSrc, nYSrc, nWidth, nHeight, GdiInterop.TernaryRasterOperations.SRCCOPY);
        //GdiInterop.BitBlt (hdc, rectangleDst.Left, rectangleDst.Top, rectangleDst.Width, rectangleDst.Height, memdc, nXSrc, nYSrc, GdiInterop.TernaryRasterOperations.SRCCOPY); //put it here, if you did not mention stretching the source image
        GdiInterop.DeleteObject (bmp);
        GdiInterop.DeleteDC (memdc);
        graphics.ReleaseHdc (hdc);
      }
    }
    public class GdiInterop
    {
      public enum TernaryRasterOperations
      {
        SRCCOPY = 0x00CC0020, // dest = source
      };
      public enum Bool
      {
        False = 0,
        True
      };
      [DllImport ("gdi32.dll", ExactSpelling = true, SetLastError = true)]
      public static extern IntPtr CreateCompatibleDC (IntPtr hDC);
      [DllImport ("gdi32.dll", ExactSpelling = true, SetLastError = true)]
      public static extern Bool DeleteDC (IntPtr hdc);
      [DllImport ("gdi32.dll", ExactSpelling = true)]
      public static extern IntPtr SelectObject (IntPtr hDC, IntPtr hObject);
      [DllImport ("gdi32.dll", ExactSpelling = true, SetLastError = true)]
      public static extern Bool DeleteObject (IntPtr hObject);
      [DllImport ("gdi32.dll", ExactSpelling = true, SetLastError = true)]
      public static extern Bool BitBlt (IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjSource, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);
      [DllImport ("gdi32.dll", ExactSpelling = true, SetLastError = true)]
      public static extern Bool StretchBlt (IntPtr hObject, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hObjSource, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, TernaryRasterOperations dwRop);
      [DllImport ("gdi32.dll", ExactSpelling = true, SetLastError = true)]
      public static extern Bool SetStretchBltMode (IntPtr hObject, int nStretchMode);
    }
