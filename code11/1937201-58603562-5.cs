    async void OnErrorPropagate(IDataflowBlock block1, IDataflowBlock block2)
    {
        await Task.WhenAny(block1.Completion); // Safe awaiting
        if (block1.Completion.IsFaulted)
            block2.Fault(block1.Completion.Exception.InnerException);
    }
