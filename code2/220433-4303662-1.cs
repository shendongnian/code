    public int LargeMethod()
    {
        int result = 0;
        Task<int> t1 = new Task<int>(SmallMethodA);
        Task<int> t2 = new Task<int>(SmallMethodB);
        t1.Start();
        t2.Start();
        result += t1.Result;
        result += t2.Result;
        return result;
    }
