    var buffer = new BlockingCollection<string>(boundedCapacity: 10);
    var producer = Task.Factory.StartNew(() =>
    {
        var random = new Random();
        var sb = new StringBuilder();
        for (int i = 0; i < 10000; i++) // 10,000 chunks
        {
            sb.Clear();
            for (int j = 0; j < 100; j++) // 100 lines each chunk
            {
                sb.AppendLine(random.Next().ToString());
            }
            buffer.Add(sb.ToString());
        }
        buffer.CompleteAdding();
    }, TaskCreationOptions.LongRunning);
    var consumer = Task.Factory.StartNew(() =>
    {
        using (var outputFile = new StreamWriter(@".\..\..\Huge.txt"))
            foreach (var chunk in buffer.GetConsumingEnumerable())
            {
                outputFile.Write(chunk);
            }
    }, TaskCreationOptions.LongRunning);
    Task.WaitAll(producer, consumer);
