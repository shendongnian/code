c#
var input = @"p0.Equals(""Testing"", 3)";
var p0 = Expression.Parameter(typeof(string), "p0");
var expression = DynamicExpressionParser.ParseLambda(new[] { p0 }, typeof(bool), input);
Delegate del = expression.Compile();
var result = del.DynamicInvoke("testing") as bool?;
  [1]: https://github.com/StefH/System.Linq.Dynamic.Core
