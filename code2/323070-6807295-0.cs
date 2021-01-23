    public static void Test(params object[] args)
    {
        if (args.Any(a => a == null))
        {
            throw new ArgumentNullException("args");
        }
    }
