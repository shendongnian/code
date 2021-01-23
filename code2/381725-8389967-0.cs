    public class HorizontalTextAlignConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if( value is HorizontalAlignment )
            {
                switch( (HorizontalAlignment)value )
                {
                    case HorizontalAlignment.Center:
                        return TextAlignment.Center;
                    case HorizontalAlignment.Left:
                        return TextAlignment.Left;
                    case HorizontalAlignment.Right:
                        return TextAlignment.Right;
                    case HorizontalAlignment.Stretch:
                        return TextAlignment.Justify; //Arbitrary
                }
            }
            throw new ArgumentException("This converter is intended to convert HorizontalAlignment to TextAlignment and vice versa.");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
