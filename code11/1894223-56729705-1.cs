    public class Bool2VisibilityConverter : MarkupExtension, IValueConverter
    	{
    		static Bool2VisibilityConverter _converter;
    		
    		public override object ProvideValue(IServiceProvider serviceProvider)
    		{
    			if (_converter == null)
    			{
    				_converter = new Bool2VisibilityConverter();
    			}
    			return _converter;
    		}
    
    		#region IValueConverter Members
    		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    		{
                var dic = value as ObservableDictionaray<YourTypesHere>;
                if (dic == null)
                  return Visibility.Collapsed;
                
                bool visible = /* Check the Dictionary with your logic */;
    			return (bool) visible ? Visibility.Visible : Visibility.Collapsed;
    		}
    
    		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    		{
    			throw new NotImplementexException();
    		}
    		#endregion
    	}
