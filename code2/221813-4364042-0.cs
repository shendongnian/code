    public static void ProcessBatches(TextReader reader,
        Func<string, bool> delimiterDetector,
        Action<List<string>> batchAction)
    {
        string line;
        List<string> batch = new List<string>();
        while ((line = reader.ReadLine()) != null)
        {
            if (delimiterDetector(line))
            {
                batchAction(batch);
                batch = new List<string>();
            }
        }
        batchAction(batch);
    }
