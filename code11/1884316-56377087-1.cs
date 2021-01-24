    public class EqualityToColorConverter : IValueConverter
    {
    	public Color EqualityColor { get; set; }
    
    	public Color InequalityColor { get; set; }
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    
    		if (value == null || parameter == null)
    			return InequalityColor;
    
    		if (parameter is Binding binding && binding.Source is View view)
            {
                parameter = view.BindingContext;
            }
    
    		return value == parameter ? EqualityColor : InequalityColor;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
