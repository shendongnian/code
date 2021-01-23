    Stack<int> stack = new Stack<int>();
    stack.Push(1);
    while(stack.Count > 0)
    {
        int someValue = stack.Pop();
        //some calculation based on someValue
        if(someValue < 30000)
            stack.Push(someValue +1);
    }
