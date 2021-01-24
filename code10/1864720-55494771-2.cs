    public class AssignmentReplacer : CSharpSyntaxRewriter
    {
    	private string inMethod;
    
    	public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
    	{
    		inMethod = node.Identifier.ValueText;
    
    		return base.VisitMethodDeclaration(node);
    	}
    
    	public override SyntaxNode VisitAssignmentExpression(AssignmentExpressionSyntax node)
    	{
    		if (inMethod == "DoSomethingElse")
    		{
    			if (node.Left is IdentifierNameSyntax name &&
    			   name.Identifier.Text == "_visited")
    			{
    
    				return node.Update(node.Left,
    								   node.OperatorToken,
    								   SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression));
    			}
    		}
    
    		return base.VisitAssignmentExpression(node);
    	}
    }
