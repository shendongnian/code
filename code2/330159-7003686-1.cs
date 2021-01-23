<!-- -->
	// Note that this code might be quite the crap, it's just a sketchy example implementation.
	public class MeanConverter : IMultiValueConverter
	{
		/// <summary>
		/// Name of the property which should be evaluated.
		/// </summary>
		public string PropertyName { get; set; }
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var items = values[0] as ReadOnlyObservableCollection<object>;
			double accscore = 0;
			PropertyInfo property = null;
			foreach (var item in items)
			{
				if (property == null)
				{
					property = item.GetType().GetProperty(PropertyName);
				}
				var value = property.GetValue(item, null);
				accscore += (double)System.Convert.ChangeType(value, typeof(double));
			}
			var output = accscore/items.Count;
			return output.ToString();
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
