    public class CalcOffsetY : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var tbk = (TextBlock)values[0];
            var offsetY = tbk.TranslatePoint(tbk.RenderTransformOrigin, (UIElement)tbk.Tag).Y -
                tbk.Margin.Top;
            var y = ((YourModelType)tbk.DataContext).Y;
            tbk.SetCurrentValue(TextBlock.MarginProperty, new Thickness(tbk.Margin.Left, y > offsetY ? y - offsetY : 0,
                tbk.Margin.Right, tbk.Margin.Bottom));
            tbk.UpdateLayout(); // Update layout immediately, so next item will get correct result.
            return Binding.DoNothing; // Already nothing to do.
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
