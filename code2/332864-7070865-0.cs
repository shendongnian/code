    class SolidColorBrushToGradientConverter : IValueConverter
    {
        const float DefaultLowColorScale = 0.95F;
    
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            var solidColorBrush = value as SolidColorBrush;
    
            if (!targetType.IsAssignableFrom (typeof (LinearGradientBrush)) || solidColorBrush == null)
            {
                return Binding.DoNothing;
            }
    
            var lowColorScale = ParseParameterAsDouble (parameter);
    
            var highColor = solidColorBrush.Color;
            var lowColor = Color.Multiply (highColor, lowColorScale);
            lowColor.A = highColor.A;
    
            return new LinearGradientBrush (
                highColor,
                lowColor,
                new Point (0, 0),
                new Point (0, 1)
                );
        }
    
        static float ParseParameterAsDouble (object parameter)
        {
            if (parameter is float)
            {
                return (float)parameter;
            }
            else if (parameter is string)
            {
                float result;
                return float.TryParse(
                    (string) parameter, 
                    NumberStyles.Float, 
                    CultureInfo.InvariantCulture, 
                    out result
                            )
                            ? result
                            : DefaultLowColorScale
                    ;
            }
            else
            {
                return DefaultLowColorScale;
            }
        }
    
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
