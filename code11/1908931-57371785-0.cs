    class Imageconverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null)
                    return null;
                string imgDir = @"\Imgs\";
                string fileName = System.IO.Path.Combine(imgDir,String.Format("{0}.jpg", value.ToString()));
    
    
                if (!System.IO.File.Exists(fileName))
                    return null;
    
                BitmapImage src = new BitmapImage();
                src.UriSource = new Uri(fileName, UriKind.Absolute);
                
                return src;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
