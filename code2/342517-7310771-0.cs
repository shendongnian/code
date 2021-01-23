    public class ImageSourceExtension
    {
        public static DependencyProperty ImageSourceProperty =
            DependencyProperty.RegisterAttached("ImageSource",
                                                typeof(ImageSource),
                                                typeof(ImageSourceExtension),
                                                new PropertyMetadata(null));
        public static ImageSource GetImageSource(DependencyObject target)
        {
            return (ImageSource)target.GetValue(ImageSourceProperty);
        }
        public static void SetImageSource(DependencyObject target, ImageSource value)
        {
            target.SetValue(ImageSourceProperty, value);
        }
    }
