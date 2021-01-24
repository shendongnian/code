    public class NodeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TreeFolder)
            {
                return new BitmapImage(new Uri("/images/folder.png", UriKind.Relative));
            }
            if (value is TreeNode)
            {
                return new BitmapImage(new Uri("/images/subroutine.png", UriKind.Relative));
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
