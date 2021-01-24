	namespace Framework
	{
		public delegate int MyApiSignature(int a, string b, char c);
		public class Core
		{
			static public void RegisterMethod(MyApiSignature method) 
			{
                //Doesn't even have to actually do anything
			}
		}
	}
	namespace Custom
	{
		using Framework;
		class Foo
		{
			public Foo()
			{
				Core.RegisterMethod(MethodA);  //Works
				Core.RegisterMethod(MethodB);  //Compile-time error
			}
			public int MethodA(int a, string b, char c)
			{
				return 0;
			}
			public int MethodB(int a, string b, byte c)
			{
				return 0;
			}
		}
	}
