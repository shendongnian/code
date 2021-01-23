    int fac(int x)
    {
        Stack<int> stack = new Stack<int>();
        int result;
        while (true)
        {
            if (x == 0)
            {
                result = 1;
                break;
            }
    
            stack.Push(x);
            x = x - 1;
        }
        while (stack.Count != 0)
        {
            x = stack.Pop();
            result = x * result;
        }
        return result;
    }
