	using System;
	
	public class MyClass
	{
		delegate void DelegateType();
		public static void Main()
		{
			DelegateType obj = method;
			obj.Method.Invoke(null, null);
			
			if (obj is System.Delegate)
				Console.WriteLine("Type is a delegate");
			else		
				Console.WriteLine("Type is NOT a delegate");
		}
		
		private static void method() {Console.WriteLine("Invoked");}
	}
