    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    namespace MyConverters
    {
        [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
        class BoolToColorBrushConverter : IValueConverter
        {
            #region Implementation of IValueConverter
            /// <summary>
            /// 
            /// </summary>
            /// <param name="value">Bolean value controlling wether to apply color change</param>
            /// <param name="targetType"></param>
            /// <param name="parameter">A CSV string on the format [ColorNameIfTrue;ColorNameIfFalse;OpacityNumber] may be provided for customization, default is [LimeGreen;Transperent;1.0].</param>
            /// <param name="culture"></param>
            /// <returns>A SolidColorBrush in the supplied or default colors depending on the state of value.</returns>
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color;
            // Setting default values
            var colorIfTrue = Colors.LimeGreen;
            var colorIfFalse = Colors.Transparent;
            double opacity = 1;
            // Parsing converter parameter
            if (parameter != null)
            {
                // Parameter format: [ColorNameIfTrue;ColorNameIfFalse;OpacityNumber]
                var parameterstring = parameter.ToString();
                if (!string.IsNullOrEmpty(parameterstring))
                {
                    var parameters = parameterstring.Split(';');
                    var count = parameters.Length;
                    if (count > 0 && !string.IsNullOrEmpty(parameters[0]))
                    {
                        colorIfTrue = ColorFromName(parameters[0]);
                    }
                    if (count > 1 && !string.IsNullOrEmpty(parameters[1]))
                    {
                        colorIfFalse = ColorFromName(parameters[1]);
                    }
                    if (count > 2 && !string.IsNullOrEmpty(parameters[2]))
                    {
                        double dblTemp;
                        if (double.TryParse(parameters[2], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture.NumberFormat, out dblTemp))
                            opacity = dblTemp;
                    }
                }
            }
            // Creating Color Brush
            if ((bool) value)
            {
                color = new SolidColorBrush(colorIfTrue);
                color.Opacity = opacity;
            }
            else
            {
                color = new SolidColorBrush(colorIfFalse);
                color.Opacity = opacity;
            }
            return color;
        }
    }
