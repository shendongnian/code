	using System.Reflection;
	
	class Test
	{
		static object MakeTest()
		{
			return Activator.CreateInstance(
				MethodBase.GetCurrentMethod().DeclaringType);
		}
		
		void Hello() { Console.WriteLine("Hi!"); }
		
		static void Main()
		{
			dynamic test = MakeTest();
			test.Hello();
		}
	}
