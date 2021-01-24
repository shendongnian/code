	public class Program
	{
		public static void Main()
		{
			var allValues = Enum.GetValues(typeof (MyEnum))
				.Cast<MyEnum>()
				.Except(new[]{MyEnum.D})
				.ToArray();
			foreach (var val in allValues)
			{
				Console.WriteLine(val);
			}
		}
	}
	public enum MyEnum
	{
		A,
		B,
		C,
		D
	}
