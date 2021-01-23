    /// SomeThreadTask defines the work a thread needs to do and also provides any data ///required along with callback pointers etc.
    /// Populate a new SomeThreadTask instance with a synch context and callnbackl along with ///any data the thread needs
    /// then start the thread to execute the task.
    /// </summary>
    public class SomeThreadTask
    {
        private string _taskId;
        private SendOrPostCallback _completedCallback;
        private SynchronizationContext _synchronizationContext;
        /// <summary>
        /// Get instance of a delegate used to notify the main thread when done.
        /// </summary>
        internal SendOrPostCallback CompletedCallback
        {
            get { return _completedCallback; }
        }
        /// <summary>
        /// Get SynchronizationContext for main thread.
        /// </summary>
        internal SynchronizationContext SynchronizationContext
        {
            get { return _synchronizationContext; }
        }
        /// <summary>
        /// Thread entry point function.
        /// </summary>
        public void ExecuteThreadTask()
        {
            //Just sleep instead of doing any real work
            Thread.Sleep(5000);
            string message = "This is some spoof data from thread work.";
            // Execute callback on synch context to tell main thread this task is done.
            SynchronizationContext.Post(CompletedCallback, (object)message);
        }
        public SomeThreadTask(SynchronizationContext synchronizationContext, SendOrPostCallback callback)
        {
            _synchronizationContext = synchronizationContext;
            _completedCallback = callback;
        }
    }
