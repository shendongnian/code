    public static class EnumerationExtensions
	{
		public static string GetDescription(this Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());
			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes( typeof(DescriptionAttribute), false);
			return attributes.Length > 0 ? attributes[0].Description : value.ToString();
		}
        public static IEnumerable<TEnum> GetEnumCollection<TEnum>(bool skipFirst = false)
		{
			var result = new List<TEnum>();
			var enums = Enum.GetValues(typeof(TEnum));
			for (int i = 0; i < enums.Length; i++)
			{
				if (skipFirst && i == 0) continue; //Some enums use "Invalid" or "Default" as first value
				TEnum e = (TEnum)enums.GetValue(i);
				result.Add(e);
			}
			return result;
		}
    }
