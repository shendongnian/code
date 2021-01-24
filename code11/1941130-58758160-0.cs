using System;
using System.Linq.Expressions;
					
public class Visitor : ExpressionVisitor
{
    public ParameterExpression Target { get; set; } 
	public ParameterExpression Replacement { get; set; } 
    protected override Expression VisitParameter(ParameterExpression node)
	{
	    return node == Target ? Replacement : base.VisitParameter(node);
	} 
}
public class Program
{
	public static void Main()
	{
		var obj = Expression.Variable(typeof(string));
		var item = Expression.Property(obj, "Length");
		
		var otherObj = Expression.Variable(typeof(string));
		var replacedItem = new Visitor()
		{
			Target = obj, 
			Replacement = otherObj, 
		}.Visit(item);
	}
}
The visitor will visit every node in the expression, recursively. When finds a ParameterExpression, it checks to see whether it's the variable we want to replace: if it is, it returns the replacement. The end result is an expression which is the same as the input, but every occurrence of the target variable has been replaced by the replacement. 
