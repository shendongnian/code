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
        while(!param.Stop)
        {
            Operation1();
            Invoke(new UpdateDelegate(updateState));
            Operation2();
            Invoke(new UpdateDelegate(updateState));
            Thread.Sleep(60000);
        }
    }
