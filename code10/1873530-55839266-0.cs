    void Main()
    {
        var random = new Random();
        var readBlock = new TransformBlock<int, int>(x => {  return DoSomething(x, "readBlock"); },
                new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1 }); //1
    
        var braodcastBlock = new BroadcastBlock<int>(i => i); // ⬅️ Here
    
        var processBlock1 =
            new TransformBlock<int, int>(x => DoSomething(x, "processBlock1")); //2
        var processBlock2 =
            new TransformBlock<int, int>(x => DoSomething(x, "processBlock2")); //3
    
        var saveBlock =
            new ActionBlock<int>(
            x => Save(x)); //4
    
        readBlock.LinkTo(braodcastBlock, new DataflowLinkOptions { PropagateCompletion = true });
    
        braodcastBlock.LinkTo(processBlock1,
            new DataflowLinkOptions { PropagateCompletion = true }); //5
    
        braodcastBlock.LinkTo(processBlock2,
            new DataflowLinkOptions { PropagateCompletion = true }); //6
    
    
        processBlock1.LinkTo(
            saveBlock); //7
    
        processBlock2.LinkTo(
            saveBlock); //8
    
        readBlock.Post(1); //10
        readBlock.Post(2); //10
    
        Task.WhenAll(
                    processBlock1.Completion,
                    processBlock2.Completion)
                    .ContinueWith(_ => saveBlock.Complete());
    
        readBlock.Complete(); //12
        saveBlock.Completion.Wait(); //13
        Console.WriteLine("Processing complete!");
    }
    
    // Define other methods and classes here
    
    private static int DoSomething(int i, string method)
    {
        Console.WriteLine($"Do Something, callng method : { method} {i}");
        return i;
    }
    private static Task<int> DoSomethingAsync(int i, string method)
    {
        DoSomething(i, method);
        return Task.FromResult(i);
    }
    private static void Save(int i)
    {
        Console.WriteLine("Save! " + i);
    }
