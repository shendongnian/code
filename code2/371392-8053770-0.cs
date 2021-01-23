	class PassActionTest
	{
		public void Test( )
		{
			var c = new C();
			var myClass =  new MyClass(c.MethodA); 
		}
	}
	class MyClass
	{
		public MyClass(Action<object,object> action)
		{
			string methodName = action.Method.Name;
		}
	}
	class C
	{
		public void MethodA(object param1, object param2)
		{
		}
	}
