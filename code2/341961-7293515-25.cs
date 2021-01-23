    int fac(int x)
    {
        Stack<int> stack = new Stack<int>();
        while (x != 0)
        {
            stack.Push(x);
            x = x - 1;
        }
        int result = 1;
        while (stack.Count != 0)
        {
            x = stack.Pop();
            result = x * result;
        }
        return result;
    }
