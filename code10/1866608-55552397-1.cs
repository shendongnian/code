    public void runInParallel()
    {
        var DataToOperateOn = CreateDictionary();
        Parallel.For(0, DataToOperateOn.Count, i =>
        {
            processList(DataToOperateOn[i.ToString()]);
        });
    }
