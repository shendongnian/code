    void disp()
    {
        try
        {
            while (stopThread == false)
            {
                listBox1.Invoke(tickerDelegate1, new object[] { DateTime.Now.ToString() });
                Thread.Sleep(1000);
            }
        }
        catch(ThreadInterruptedException)
        {
            // ignore the exception since the thread should terminate
        }
    }
