    var schemaObject = new SchemaObjectName();
    schemaObject.Identifiers.Add(new Identifier {Value = "MyTable"});
    var queryExpression = new QuerySpecification();
    queryExpression.FromClauses.Add(
        new SchemaObjectTableSource {SchemaObject = schemaObject});
    // Add the expression from before (repeat as necessary) 
    Literal zeroLiteral = new Literal
    {
        LiteralType = LiteralType.Integer,
        Value = "0",
    };
    Literal oneLiteral = new Literal
    {
        LiteralType = LiteralType.Integer,
        Value = "1",
    };
    WhenClause whenClause = new WhenClause
    {
        WhenExpression = expr, // <-- here
        ThenExpression = oneLiteral,
    };
    CaseExpression caseExpression = new CaseExpression
    {
        ElseExpression = zeroLiteral,
    };
    caseExpression.WhenClauses.Add(whenClause);
    queryExpression.SelectElements.Add(caseExpression);
    var selectStatement = new SelectStatement {QueryExpression = queryExpression};
