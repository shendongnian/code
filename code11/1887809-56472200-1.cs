c#
var input = @"p0.Equals(""Testing"", 3)";
var p0 = Expression.Parameter(typeof(string), "p0");
var expression = DynamicExpressionParser.ParseLambda(new[] { p0 }, typeof(bool), input);
Delegate del = expression.Compile();
var result = del.DynamicInvoke("testing") as bool?;
**UPDATE**
I've changed the code for [System.Linq.Dynamic.Core][1] (version 1.0.16). Now it's also possible to use:
c#
var input = @"p0.Equals(""Testing"", StringComparison.InvariantCultureIgnoreCase)";
// ...
  [1]: https://github.com/StefH/System.Linq.Dynamic.Core
