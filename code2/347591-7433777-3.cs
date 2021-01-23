    BinaryExpression expression = ((BinaryExpression)e.Body);
    string name = ((MemberExpression)expression.Left).Member.Name;
    Expression value = expression.Right;
    Console.WriteLine(name);
    Console.WriteLine(value);
