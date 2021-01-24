    // Usage Example
    static void Main()
    {
		var chanelDesc = Channel.Wholesale.GetEnumDescriptionValue();
		Console.WriteLine(chanelDesc);
		Console.ReadKey();
	}
    public static class EnumExtensions
	{
		public static string GetEnumDescriptionValue<T>(this T @enum) where T : struct
		{
			if(!typeof(T).IsEnum)
				throw new InvalidOperationException();
			return typeof(T).GetField(@enum.ToString()).GetCustomAttribute<DescriptionAttribute>(false).Description;
		}
	}
    public enum Channel
	{
		[Description("Banked - Retail")]
		Dtc,
		Correspondent,
		[Description("Banked - Wholesale")]
		Wholesale
	}
