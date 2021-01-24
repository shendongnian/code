    public Tuple<string, List<object>> Get<TMember>(Expression<Func<TMember, IValidatorExpression, bool>> exp, string propName)
    {
        var visitor = new ValueExtractor();
        visitor.Visit(exp);
        foreach (var argument in visitor.Arguments)
            Console.WriteLine(argument);
