	using System;
	
	public class MyClass {
		public static void Main() 	{ 
			TestClass tc = new TestClass();
			tc.Str1 = "Hello";
			tc.Str2 = "World!"; // will not be set because of enforced constraint
			Console.WriteLine(tc.Str1);
			Console.WriteLine(tc.Str2);
			Console.ReadKey();
		}
	}
	
	public class TestClass {
		private string _str1;
		public string Str1 	{
			get { return _str1; }
			set {
				if (string.IsNullOrEmpty(Str2))
					_str1 = value;
			}
		}
		
		private string _str2;
		public string Str2 	{
			get { return _str2; }
			set {
				if (string.IsNullOrEmpty(Str1))
					_str2 = value;
			}
		}
	}
