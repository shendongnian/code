    public delegate void DoneDelegate (object calculationResults);
    public class MyWorker
    {
        public DoneDelegate Done { get; set; }
        public void Go()
        {
            object results = null;
            // do some work
            Done(results);
        }
    }
    public class Main
    {
        public void StartWorker()
        {
            MyWorker worker = new MyWorker();
            worker.Done = new DoneDelegate(DoneCallback);
            System.Threading.Thread thread = new System.Threading.Thread(worker.Go);
            thread.IsBackground = true;
            thread.Start();
        }
        public void DoneCallback (object results)
        {
            // use the results
        }
    }
