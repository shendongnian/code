	public static class NumericType
	{
		public const string Dollars = "{0:0.00}";
		public const string Hours = "{0:0.000}";
		public const string PayRate = "{0:0.0000}";
	}
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class DecimalFormatAttribute : System.Attribute
	{
		public string Format { get; } = "{0}";
		public DecimalFormatAttribute(string format) => Format = format;
	}
	public class MyDecimalConverter : DefaultTypeConverter
	{
		public string Format { get; } = "{0}";
		
		public MyDecimalConverter(string format) => Format = format;
		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is decimal d)
                return (d == 0) ? string.Empty : string.Format(Format, d);
            return base.ConvertToString(value, row, memberMapData);
        }
	}
	public static class CsvHelpExtensions
	{
		public static void RegisterDecimalFormats<T>(this ClassMap<T> map)
		{
			foreach (var property in typeof(T).GetProperties())
			{
				var attr = property.GetCustomAttribute<DecimalFormatAttribute>();
				if (attr != null)
					map.Map(typeof(T), property, true).TypeConverter(new MyDecimalConverter(attr.Format));
			}
		}
	}
