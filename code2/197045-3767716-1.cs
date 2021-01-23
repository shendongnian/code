	using System;
	using System.Globalization;
	using System.Windows;
	using System.Windows.Data;
	namespace StackOverflow2
	{
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
			}
		}
		public class HourToDateConverter : IValueConverter
		{
			public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			{
				object result = DependencyProperty.UnsetValue;
				if (value is double)
					result = DateTime.Now.Date.AddHours((double)value);
				return result;
			}
			public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			{
				throw new NotImplementedException();
			}
		}
	}
