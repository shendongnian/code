    public class MyThread
    {
        Thread _thread;
    
        public MyThread()
        { 
            _thread = new Thread(WorkerMethod);
        }
        public void Start()
        {
            _thread.Start();
        }
    
        private void WorkerMethod()
        {
            // do something useful
            // [...]
        
            //Exiting this method = exit thread => trigger event
            Exited(this, EventArgs.Empty);
        }
    
        public event EventHandler Exited = delegate{};
    }
