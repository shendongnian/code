    public class WorkerParams
    {
        public bool Stop = false;
    }
    private void TestForm_Load(object sender, EventArgs e)
    {
        _thread = new Thread(lonRunThread);
        _thread.Start(new WorkerParams());
    }
    public void lonRunThread(object argument)
    {
        WorkerParams param = argument as WorkerParams;
        DateTime lastExec = DateTime.MinValue;
        while(!param.Stop)
        {
            if (new TimeSpan(DateTime.Now.Ticks - lastExec.Ticks).TotalSeconds >= 60)
            {
                Operation1();
                Invoke(new UpdateDelegate(updateState));
                Operation2();
                Invoke(new UpdateDelegate(updateState));
                lastExec = DateTime.Now;
            }
            Thread.Sleep(500);
        }
    }
