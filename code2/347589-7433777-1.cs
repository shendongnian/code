    BinaryExpression expression = ((BinaryExpression)e.Body);
    Expression name = expression.Left;
    Expression value = expression.Right;  
    Console.WriteLine(name);
    Console.WriteLine(value );
