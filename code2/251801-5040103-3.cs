    static async Task<int> Func(int n)
    {
        int result;
        try
        {
            result = await HelperMethod(n);
        }
        finally
        {
            Console.WriteLine("    Func: Finally #{0}", n);
        }
        // since Func(...)'s return statement is outside the try/finally,
        // the finally body is certain to execute first, even in face of this bug.
        return result;
    }
    static async Task<int> HelperMethod(int n)
    {
        Console.WriteLine("    Func: Begin #{0}", n);
        await TaskEx.Delay(100);
        Console.WriteLine("    Func: End #{0}", n);
        return 0;
    }
