    private void button1_Click(object sender, EventArgs e)
    {
        BlockingCollection<string> blockingQueue = new BlockingCollection<string>();
        // Start DoStuff on parallel thread
        Task.Run(() => DoStuff(blockingQueue));
        // Wait for DoRun to finish AND get the result at the same time
        string result = blockingQueue.Take();
        MessageBox.Show(result);
    }
    private void DoStuff(BlockingCollection<string> result)
    {
        // Simulate work
        Thread.Sleep(1000);
        // return result
        result.Add("SomeResultValue");
    }
