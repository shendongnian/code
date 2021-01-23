    var schemaObject = new SchemaObjectName();
    schemaObject.Identifiers.Add(new Identifier {Value = "MyTable"});
    var queryExpression = new QuerySpecification();
    queryExpression.FromClauses.Add(
        new SchemaObjectTableSource {SchemaObject = schemaObject});
    // Add the expression from before (repeat as necessary) 
    queryExpression.SelectElements.Add(expr);
    var selectStatement = new SelectStatement {QueryExpression = queryExpression};
