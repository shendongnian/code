Csharp
static object CreateShape(string shapeDescription)
{
    switch (shapeDescription)
    {
        case var o when (o?.Trim().Length ?? 0) == 0:
            // white space
            return null;
        default:
            return "invalid shape description";
    }            
}
We can take the above code and feed it into [RoslynQuoter](https://roslynquoter.azurewebsites.net/) to see how to generate it and it would look something like:
CasePatternSwitchLabel(
            VarPattern(
                SingleVariableDesignation(
                    Identifier("o"))),
            Token(SyntaxKind.ColonToken))
        .WithWhenClause(
            WhenClause(
                BinaryExpression(
                    SyntaxKind.EqualsExpression,
                    ParenthesizedExpression(
                        BinaryExpression(
                            SyntaxKind.CoalesceExpression,
                            ConditionalAccessExpression(
                                IdentifierName("o"),
                                MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    InvocationExpression(
                                        MemberBindingExpression(
                                            IdentifierName("Trim"))),
                                    IdentifierName("Length"))),
                            LiteralExpression(
                                SyntaxKind.NumericLiteralExpression,
                                Literal(0)))),
                    LiteralExpression(
                        SyntaxKind.NumericLiteralExpression,
                        Literal(0)))))))
