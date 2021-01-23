public class MyConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		System.Collections.IList collection = value as System.Collections.IList;
		ListCollectionView view = new ListCollectionView(collection);
		SortDescription sort = new SortDescription(parameter.ToString(), ListSortDirection.Ascending);
		view.SortDescriptions.Add(sort);
		return view;
	}
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return null;
	}
}
