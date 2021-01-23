    static void MethodGroup()
    {
        new List<string>().ForEach(Console.WriteLine);
    }
    static void LambdaExpression()
    {
        new List<string>().ForEach(x => Console.WriteLine(x));
    }
