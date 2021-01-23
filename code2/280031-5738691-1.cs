    public class ComboBoxItemsSourceFilter : IMultiValueConverter
    {
    	#region IMultiValueConverter Members
    
    	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    	{
    		var collection = new List<object>((object[])values[0]);
    		foreach (var item in values.Skip(1))
    		{
    			collection.Remove(item);
    		}
    		return collection;
    	}
    
    	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    
    	#endregion
    }
