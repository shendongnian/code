	public class MilestoneItemsSourceCreator : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var input = value as Milestone;
			CompositeCollection collection = new CompositeCollection();
			collection.Add(new CollectionContainer(){ Collection = input.SubMilestones });
			collection.Add(new CollectionContainer(){ Collection = input.Activities });
			return collection;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
