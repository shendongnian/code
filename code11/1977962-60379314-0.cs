	using System;
	using System.Linq.Expressions;
	namespace SO60378405
	{
		static class Program
		{
			static void Main(string[] args)
			{
				var foo = new SomeContainer("hello", 123);
				Get(foo, s => s.SomeString, s => s.SomeInt);
			}
			static void Get<T>(T foo, params Expression<Func<T, object>>[] expressions)
			{
				foreach (var expression in expressions)
				{
					var memberExpression = GetMemberExpression(expression);
					var propertyName = memberExpression.Member.Name;
					var propertyGetter = expression.Compile();
					var propertyValue = propertyGetter(foo);
					Console.WriteLine($"{propertyName} = '{propertyValue}'");
				}
			}
			static MemberExpression GetMemberExpression<T>(Expression<Func<T, object>> expression)
			{
				switch (expression.Body)
				{
					case MemberExpression memberExpression:
						return memberExpression; //string
					case UnaryExpression unaryExpression when unaryExpression.Operand is MemberExpression operandMemberExpression:
						return operandMemberExpression; //int, decimal
					default:
						throw new InvalidOperationException();
				}
			}
		}
		public class SomeContainer
		{
			public string SomeString { get; set; }
			public int SomeInt { get; set; }
			public SomeContainer(string someString, int someInt)
			{
				SomeString = someString;
				SomeInt = someInt;
			}
		}
	}
