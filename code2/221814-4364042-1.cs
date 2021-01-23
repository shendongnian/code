    using (TextReader reader = File.OpenText("foo.csv"))
    {
        ProcessBatch(reader, line => line == "# DELTA,1", BatchAction);
    }
    ...
    private static void BatchAction(List<string> batch)
    {
        ...
    }
