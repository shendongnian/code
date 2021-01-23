    public class MyConverter : TypeConverter
    {
    
    	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    	{
    		if (value is CategoriesList) {
    			return value.ToString();
    		}
    		return base.ConvertFrom(context, culture, value);
    	}
    }
