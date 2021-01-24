    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
        /// <summary>
        /// Convert a winforms image to a wpf-usable imageSource
        /// </summary>
        /// <param name="bitmap">winforms image</param>
        /// <returns>wpf imageSource object</returns>
        public static ImageSource ToImageSource(this System.Drawing.Bitmap bitmap)
        {
          var hbitmap = bitmap.GetHbitmap();
          try
          {
            var imageSource = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(bitmap.Width, bitmap.Height));
        
            return imageSource;
          }
          finally
          {
            Gdi32.DeleteObject(hbitmap);
          }
        }
