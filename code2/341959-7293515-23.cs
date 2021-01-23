    int fac(int x)
    {
        Stack<int> stack = new Stack<int>();
        int result;
    start:
        if (x == 0)
        {
            result = 1;
            goto end;
        }
        stack.Push(x);
        x = x - 1;
        goto start;
    end:
        if (stack.Count != 0)
        {
            x = stack.Pop();
            result = x * result;
            goto end;
        }
        return result;
    }
