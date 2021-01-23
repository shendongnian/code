    private bool VisitExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
    {
    	if (expression.ExpressionType == ExpressionType.VariableDeclarator)
    	{
    		VariableDeclaratorExpression declaratorExpression = (VariableDeclaratorExpression)expression;
    		if (declaratorExpression.Initializer == null)
    		{
    			this.AddViolation(parentElement, expression.LineNumber, "YourRule", declaratorExpression.Identifier.Text);
    		}
    	}
    
    	return true;
    }
