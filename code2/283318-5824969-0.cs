    [ValueConversion(typeof(System.Drawing.Bitmap), typeof(ImageSource))
    public class BitmapToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bmp = value as System.Drawing.Bitmap;
            if (bmp == null)
                return null;
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        bmp.GetHBitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
