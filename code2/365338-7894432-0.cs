	public class InstancePatternString  : PatternString
	{
	    public InstancePatternString(string pattern): base(pattern)
		{
		}
	
	    public override void ActivateOptions()
	    {
	        AddConverter("cs", typeof(InstancePatternConverter));
	        base.ActivateOptions();
	    }
	}
	public class InstancePatternConverter  : PatternConverter 
	{
	    override protected void Convert(TextWriter writer, object state) 
		{
			switch(Option)
			{
				case "instance":
					writer.Write(MyContext.Instance);
					break;
			}
	    }
	}
	public class InstancePatternStringConverter : IConvertTo, IConvertFrom
	{
	    public bool CanConvertFrom(Type sourceType)
	    {
	        return sourceType == typeof(string);
	    }
	
	    public bool CanConvertTo(Type targetType)
	    {
	        return typeof(string).IsAssignableFrom(targetType);
	    }
	
	    public object ConvertFrom(object source)
	    {
	        var pattern = source as string;
	        if (pattern == null)
	            throw ConversionNotSupportedException.Create(typeof(InstancePatternString), source);
	        return new InstancePatternString(pattern);
	    }
	
	    public object ConvertTo(object source, Type targetType)
	    {
	        var pattern = source as PatternString;
	        if (pattern == null || !CanConvertTo(targetType))
	            throw ConversionNotSupportedException.Create(targetType, source);
	        return pattern.Format();
	    }
	}
