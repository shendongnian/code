	[ValueConversion(typeof(Visibility), typeof(bool))]
	public class VisibilityToBoolConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Visibility vis = (Visibility)value;
			switch (vis)
			{
				case Visibility.Collapsed:
					return false;
				case Visibility.Hidden:
					return false;
				case Visibility.Visible:
					return true;
			}
			return false;
		}
		public object ConvertBack(object value, Type targetType, object parameter,
			System.Globalization.CultureInfo culture)
		{
			if ((bool)value) return Visibility.Visible;
			else return Visibility.Collapsed;
		}
		#endregion
	}
