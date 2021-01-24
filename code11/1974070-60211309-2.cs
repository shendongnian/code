    private void button1_Click(object sender, EventArgs e)
    {
        BlockingCollection<string> blockingQueue = new BlockingCollection<string>();
        // Start DoStuff on parallel thread
        Task.Run(() => DoStuff(blockingQueue));
        // Wait for something to be returned from DoStuff and handle it
        foreach (string data in blockingQueue.GetConsumingEnumerable())
        {
            textBox1.AppendText(data + Environment.NewLine);
        }
        MessageBox.Show("Finished");
    }
    private void DoStuff(BlockingCollection<string> result)
    {
        for (int i = 1; i <= 10; i++)
        {
            // Simulate work
            Thread.Sleep(1000);
            // return result
            result.Add("Result number " + i);
        }
        // Signal we are done
        result.CompleteAdding();
    }
