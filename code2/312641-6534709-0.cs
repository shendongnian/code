    public class MyBackgroundWorker
    {
        // Fields
        private Delegate _target;
        private object[] _arguments;
    
        // Events
        public event EventHandler RunWorkerStarted;
        public event EventHandler<RunWorkerCompletedEventArgs> RunWorkerCompleted;
       // Event Invocators
        public void InvokeRunWorkerStarted()
        {
            var handler = RunWorkerStarted;
            if (handler != null) handler(this, new EventArgs());
        }
        public void InvokeRunWorkerCompleted(object result)
        {
            var handler = RunWorkerCompleted;
            if (handler != null) handler(this, new RunWorkerCompletedEventArgs(result));
        }
        public void RunWorkerAsync(Delegate target, params object[] arguments)
        {
            _target = target;
            _arguments = arguments;
            new Thread(DoWork).Start(arguments);
        }
        // Helper method to run the target delegate
        private void DoWork(object obj)
        {
            _target.DynamicInvoke(_arguments);
            // Retrieve the target delegate's result and invoke the RunWorkerCompleted event with it (for simplicity, I'm sending null)
            InvokeRunWorkerCompleted(null);
        }
    }
    internal class RunWorkerCompletedEventArgs : EventArgs
    {
        public RunWorkerCompletedEventArgs(object result)
        {
            Result = result;
        }
        public object Result { get; set; }
    }
