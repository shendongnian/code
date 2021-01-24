    public class CalcOffsetY : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var tbk = (TextBlock)values[0];
            var offsetY = tbk.TranslatePoint(tbk.RenderTransformOrigin, (UIElement)tbk.Tag).Y - 
                ((TranslateTransform)tbk.RenderTransform).Y;
            var y = ((YourModelType)tbk.DataContext).Y;
            return y > offsetY ? y - offsetY : 0;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
