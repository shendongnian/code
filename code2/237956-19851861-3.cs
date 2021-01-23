    public class MyClassOrForm
    {
        Thread myProcessingThread;
        public AutoResetEvent startProcessing = new AutoResetEvent(false);
        public AutoResetEvent processingFinished = new AutoResetEvent(false);
        public AutoResetEvent killProcessingThread = new AutoResetEvent(false);
        public MyClassOrForm()
        {
            myProcessingThread = new Thread(MyProcess);
        }
        private void MyProcess()
        {
            while (true)
            {
                if (startProcessing.WaitOne())
                {
                    // Do processing here
                    processingFinished.Set();
                }
                if (killProcessingThread.WaitOne(0))
                    return;
            }
        }
    }
