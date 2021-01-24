    static public class ExtensionMethods
	{
		static public General ToGeneral<T>(this T input) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum) throw new ArgumentException("Input must be an enum.");
			
			return (General)((int)(object)input & Enum.GetValues(typeof(General)).Cast<int>().Sum());
		}
		
		static public T ToEnum<T>(this General input)
		{
			if (!typeof(T).IsEnum) throw new ArgumentException("Output type must be an enum.");
            return (T)Enum.ToObject(typeof(T), (int)input & Enum.GetValues(typeof(T)).Cast<int>().Sum());
		}
	}
