        public class ByteArrayToImageSourceConverter : IValueConverter 
        {
          public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
          {   
            byte[] bytes;
            var assembly = GetType().GetTypeInfo().Assembly; // using System.Reflection;
            var stream = assembly.GetManifestResourceStream((string)value); // value = "App1.ImagesFolder.ninja.png"
            using (var ms = new MemoryStream()) // using System.IO; 
            {
                stream.CopyToAsync(ms);
                bytes = ms.ToArray();
            }
            return ImageSource.FromStream(() => new MemoryStream(bytes));
          }
          public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
          {
            return null;
          }
        }
