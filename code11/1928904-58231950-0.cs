    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;
    namespace WpfApp1
    {
        public class SlashConverter : MarkupExtension, IValueConverter
        {
            private static SlashConverter _converter = null;
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                if (_converter == null)
                {
                    _converter = new SlashConverter();
                }
                return _converter;
            }
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return (value.ToString()).Replace(@"\", @"\\");
            }
            public object ConvertBack(object value, Type targetType, object parameter,
                CultureInfo culture)
            {
                return value;
            }
        }
    }
