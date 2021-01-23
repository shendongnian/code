    var stack = new Stack<IEither<Operator, Parenthesis>>();
    stack.Push(new Left<Operator, Parenthesis>(new Operator()));
    stack.Push(new Right<Operator, Parenthesis>(new Parenthesis()));
    while (stack.Count > 0)
    {
        stack.Pop().Map(op  => Console.WriteLine("Found an operator: " + op),
                        par => Console.WriteLine("Found a parenthesis: " + par));
    }
    
