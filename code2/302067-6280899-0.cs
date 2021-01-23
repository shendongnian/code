	struct MyStruct { public int Field; }
	
	static class Program
	{
		static void Main()
		{
			var s = new MyStruct();
			s.GetType().GetField("Field").SetValueDirect(__makeref(s), 5);
			System.Console.WriteLine(s.Field); //Prints 5
		}
	}
