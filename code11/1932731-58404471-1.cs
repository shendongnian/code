    void Loop()
    {
        while (_IsRunning)
        {
            block1.Post(GetRawStreamData());
        }
        block1.Complete();
        block3.Completion.Wait(); // Optional, to wait for the last data to be processed
    }
