    public static class ImageSourceHelper
    {
        public static ImageSource GetResourceImage(string resourcePath)
        {
            return GetResourceImage(Assembly.GetCallingAssembly(), resourcePath);
        }
        public static ImageSource GetResourceImage(Assembly resourceAssembly, string resourcePath)
        {
            if (string.IsNullOrEmpty(resourcePath)) return null;
            var assembly = resourceAssembly.GetName().Name;
            const string uriFormat = "pack://application:,,,/{0};component/{1}";
            if (!UriParser.IsKnownScheme("pack")) new System.Windows.Application();
            var uri = new Uri(string.Format(uriFormat, assembly, resourcePath), UriKind.RelativeOrAbsolute);
            return BitmapFrame.Create(uri);
        }
        public static ImageSource ConvertFromGdiBitmap(Bitmap bitmap)
        {
            return Common.SystemAbstraction.Media.ImageConverter.ConvertToBitmapSource(bitmap);
        }
        public static Bitmap ConvertToGdiBitmap(ImageSource imageSource)
        {
            return Common.SystemAbstraction.Media.ImageConverter.ConvertToBitmap(imageSource as BitmapSource);
        }
    }
