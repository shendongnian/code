	public static void Main()
	{
		var d = new List<GenericObject>();
		Console.WriteLine(d.AsReadOnly().Count);
		d.Add(new GenericObject { i = 2 });
		Console.WriteLine(d.AsReadOnly().Count);
	}
	
	public class GenericObject
	{
		public int i = 0;
	}
