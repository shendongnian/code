    private void button1_Click(object sender, EventArgs e)
    {
        TestClass t = new TestClass();
        t.OnJobTaskStatusUpdate += new TestClass.JobTaskStatusUpdate(JobTaskStatusUpdateHandler);
        Thread ts = new Thread(new ThreadStart(t.RunTest));
        ts.Start();
        ts.Join();   // blocks the main thread
    }
