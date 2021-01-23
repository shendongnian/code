    public override string ToString()
    {
        return ToLiteral(Text + " '" + Value + "'");
    }
    private string ToLiteral(string input)
    {
        var writer = new StringWriter();
        CSharpCodeProvider provider = new CSharpCodeProvider();
        provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
        return writer.ToString();
    }
