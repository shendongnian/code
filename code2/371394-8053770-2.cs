	class PassActionTest
	{
		public void Test()
		{
			var myClass = new MyClass(c => c.MethodA);
		}
	}
	class MyClass
	{
		public MyClass(Func<C, Action<object, object>> action)
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
