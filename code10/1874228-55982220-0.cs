	public class JsonArrayTypeConverter<T> : TypeConverter
	{
		private static readonly TypeConverter _Converter = TypeDescriptor.GetConverter(typeof(T));
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
			sourceType == typeof(string) || TypeDescriptor.GetConverter(sourceType).CanConvertFrom(context, sourceType);
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			try
			{
				return JsonConvert.DeserializeObject<IEnumerable<T>>((string)value);
			}
			catch (Exception)
			{
				var dst = _Converter.ConvertFrom(context, culture, value); //in case this is not an array or something is broken, pass this element to a another converter and still return it as a list
				return new T[] { (T)dst };
			}
		}
	}
