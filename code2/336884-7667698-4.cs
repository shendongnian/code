    var result = 100 * new NumericReferenceExpression("Test") + 50;
    var symbolTable = new Dictionary<string, int>
    {
        { "Test", 30 }
    };
    Console.WriteLine("Pretty printed: {0}", result);
    Console.WriteLine("Evaluated: {0}", result.Evaluate(symbolTable));
