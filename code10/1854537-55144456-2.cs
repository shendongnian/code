    public static void Main(string[] args)
    {
        foreach (var batch in GetData<string>("hello world").Batch(50000))
        {
            ProcessBusinessLogic(batch);
        }
    }
