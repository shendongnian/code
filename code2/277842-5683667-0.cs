    public class SumConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		var input = value as ObservableCollection<Employee>;
    		return (from emp in input
    				select emp.Id).Sum();
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotSupportedException();
    	}
    }
