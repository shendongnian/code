    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
    private ExpressionSyntax InverseExpressionWithNot(ExpressionSyntax checkExpression)
	{
		if (checkExpression == null)
        {
            throw new ArgumentNullException(nameof(checkExpression));
        }
		return PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, ParenthesizedExpression(checkExpression));
	}
