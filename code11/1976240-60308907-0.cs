    using System;
    using System.Globalization;
    using Xamarin.Forms;
    namespace YourApp.Converters 
    {
        public class CurrencyCultureConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		    {
			    return value.ToString("C0", CultureInfo.CreateSpecificCulture("es-CL"));
		    }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		    {
			    throw new NotImplementedException();
		    }
        }
    }
