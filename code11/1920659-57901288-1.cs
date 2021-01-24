    var batchBlock = new BatchBlock<string>(batchSize: 10);
    var actionBlock = new ActionBlock<string[]>(batch =>
    {
        // Do something with the batch. For example:
        Console.WriteLine("Processing batch");
        foreach (var line in batch)
        {
            Console.WriteLine(line);
        }
    });
    batchBlock.LinkTo(actionBlock,
        new DataflowLinkOptions() { PropagateCompletion = true });
    foreach (var line in File.ReadLines(@".\..\..\_Data.txt"))
    {
        await batchBlock.SendAsync(line).ConfigureAwait(false);
    }
    batchBlock.Complete();
    await actionBlock.Completion.ConfigureAwait(false);
