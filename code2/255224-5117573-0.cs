    private void GeneratePrimitiveExpressionBase(CodePrimitiveExpression e)
    {
    ...
        else if (e.Value is string)
        {
            this.Output.Write(this.QuoteSnippetString((string) e.Value));
        }
    ...
    }
