    [ValueConversion(typeof (MyCoordObject), typeof (Brush))]
    public class CoordToBrushConverter : ConverterExtension
    {
       public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var coordObject= (MyCoordObject) value;
            if (coordObject.X == 132) return Brushes.Red; 
            //define your own brushes as StaticResource or something, this won't work
            return Brushes.Black;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //nothing
            return value;
        }
    }
