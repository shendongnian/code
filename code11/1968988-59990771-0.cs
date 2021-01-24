    var expression = new ExpressionModel();
    expression.Name = "test";
    var literal = expression.Literal;
    if (literal is null)
    {
        // No literal - create one and set it
        literal = new LiteralModel();
        expression.Literal = literal;
    }
    // Now literal is non-null either way, so set the value.
    literal.Value = "61";
