    	namespace MyNamgespace
	{
		public enum Operation
		{
			Read = 0,
			Write
		}
		public class ClassWithConstants
		{
			public const int Read = 0;
			public const int Write = 1;
		}
		internal class Program
		{
			static void Main(string[] args)
			{
				Console.WriteLine((ParseEnum("Operation.Write")));
				Console.WriteLine((ParseContant<ClassWithConstants>("Write")));
				Console.ReadLine();
			}
			static int ParseEnum(string enumValue)
			{
				var typeName = enumValue.Split('.')[0];
				var valueName = enumValue.Split('.')[1];
				var enumType = Type.GetType(string.Format("MyNamespace.{0}", typeName));
				var op = (Operation) Enum.Parse(enumType, valueName);
				return (int)op;
			}
			
			static int ParseContant<T>(string constantName)
			{
				var type = typeof (T);
				var field = type.GetField(constantName, BindingFlags.Static | BindingFlags.Public);
				return (int)field.GetValue(null);
			}
		}
	}
