    Expression expression = Expression.Parameter(typeof(Person), "x");
    
    // Serialize expression
    var serializer = new ExpressionSerializer(new JsonSerializer());
    string value = serializer.SerializeText(expression);
    Console.WriteLine("value:" + value);
    
    // Deserialize expression
    var actualExpression = serializer.DeserializeText(value);
    Console.WriteLine("actualExpression:" + actualExpression.ToJson());
