    private void button1_Click(object sender, EventArgs e)
    {
        ...
        Thread ts = new Thread(new ThreadStart(t.RunTest));
        ts.Start();
        ts.Join();   // blocks the main thread
    }
