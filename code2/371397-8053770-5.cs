	class PassActionTest
	{
		public void Test()
		{
			var myClass = new MyClass(c => c.MethodA);
		}
	}
	class MyClass
	{
		public MyClass(Expression<Func<C, Action<object, object>>> expr)
		{
			UnaryExpression unaryExpr = (UnaryExpression)expr.Body;
			MethodCallExpression methodCallExpr = (MethodCallExpression)unaryExpr.Operand;
			ConstantExpression constantExpr = (ConstantExpression)methodCallExpr.Arguments[2];
			MethodInfo methodInfo = (MethodInfo)constantExpr.Value;
			string methodName = methodInfo.Name;
		}
	}
	class C
	{
		public void MethodA(object param1, object param2)
		{
		}
	}
