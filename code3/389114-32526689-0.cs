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
            /// <param name="parameter">A string denoting the exact color name may be inserted here, default is "LimeGreen".</param>
            /// <param name="culture"></param>
            /// <returns>The supplied or default color name if True, "Transperent" if false</returns>
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var returnColor = Colors.LimeGreen;
                if (parameter != null)
                {
                    string newColor = parameter.ToString();
                    if (!string.IsNullOrEmpty(newColor))
                    {
                        returnColor = ColorFromName(newColor);
                    }
                }
                if ((bool) value)
                    return new SolidColorBrush(returnColor);
                else
                    return new SolidColorBrush(Colors.Transparent);
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
            #endregion
            public static Color ColorFromName(string colorName)
            {
                System.Drawing.Color systemColor = System.Drawing.Color.FromName(colorName);
                return Color.FromArgb(systemColor.A, systemColor.R, systemColor.G, systemColor.B);
            }
        }
    }
