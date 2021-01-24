 c#
using System;
using System.Linq.Expressions;
using System.Reflection;
class Dong
{
    public static implicit operator Dong(int i) => throw new InvalidOperationException("int");
    public static implicit operator Dong(decimal d) => throw new InvalidOperationException("decimal");
    static void Main()
    {
        decimal a = -0.5m;
        decimal b = 2m;
        Expression<Func<decimal, decimal>> f = t => a * t + b; // Linear equation of t
        Console.WriteLine(FunctionToString(f)); // Generate something like "-0.5 * t + 2"
    }
    static string FunctionToString(Expression f)
        => ConstantEvaluator.Instance.Visit(f).ToString();
    class ConstantEvaluator : ExpressionVisitor
    {
        public static ConstantEvaluator Instance { get; } = new ConstantEvaluator();
        private ConstantEvaluator() { }
        protected override Expression VisitMember(MemberExpression node)
        {
            var target = Visit(node.Expression); // applies recursion of nested contexts
            if (target is ConstantExpression c)
            {
                switch (node.Member)
                {
                    case FieldInfo field:
                        return Expression.Constant(field.GetValue(c.Value), field.FieldType);
                    case PropertyInfo prop:
                        return Expression.Constant(prop.GetValue(c.Value), prop.PropertyType);
                }
            }
            return node;
        }
    }
}
Output:
 txt
t => ((-0.5 * t) + 2)
Note that you can also use:
 c#
static string FunctionToString(LambdaExpression f)
    => ConstantEvaluator.Instance.Visit(f.Body).ToString();
if you don't want the lambda declaration; this gives output:
 txt
((-0.5 * t) + 2)
