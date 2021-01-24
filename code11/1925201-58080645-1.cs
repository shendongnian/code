// Generic Method, return type Expression<Func<User, int>>
Expression.Lambda<Func<User, int>>(sortExpression, parameter);
Instead of passing the ```typeof(Func<User, int>)``` parameter.
// Non-generic. Return type LambdaExpression
Expression.Lambda(typeof(Func<User, int>), sortExpression, parameter);
Second:
I wasn't binding the parameter properly, which made it so that the expression was accessing property of a discarded parameter that wasn't provided to the expression.
// I'm creating an expression to access the property of a newly created parameter.
var sortExpression = Expression.Property(Expression.Parameter(typeof(User)), sortBy);
var parameter = Expression.Parameter(typeof(User));
var expressionBody = Expression.Lambda<Func<User, int>>(sortExpression, parameter);
//Above causes an unbinded variable exception since there are two parameters, one of which is not passed/bound.
//Should be:
var parameter = Expression.Parameter(typeof(User));
var sortExpression = Expression.Property(parameter, sortBy);
