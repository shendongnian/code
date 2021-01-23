    // Create a delegate for our callback function.
    public delegate void SomeThreadTaskCompleted(string taskId, bool isError);
    public class SomeClass
    {
        private void DoBackgroundWork()
        {
            // Create a ThreadTask object.
            SomeThreadTask threadTask = new SomeThreadTask();
            // Create a task id.  Quick and dirty here to keep it simple.  
            // Read about threading and task identifiers to learn 
            // various ways people commonly do this for production code.
            threadTask.TaskId = "MyTask" + DateTime.Now.Ticks.ToString();
            // Set the thread up with a callback function pointer.
            threadTask.CompletedCallback = 
                new SomeThreadTaskCompleted(SomeThreadTaskCompletedCallback);
            
            
            // Create a thread.  We only need to specify the entry point function.
            // Framework creates the actual delegate for thread with this entry point.
            Thread thread = new Thread(threadTask.ExecuteThreadTask);
            // Do something with our thread and threadTask object instances just created
            // so we could cancel the thread etc.  Can be as simple as stick 'em in a bag
            // or may need a complex manager, just depends.
            // GO!
            thread.Start();
            // Go do something else.  When task finishes we will get a callback.
        }
        /// <summary>
        /// Method that receives callbacks from threads upon completion.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="isError"></param>
        public void SomeThreadTaskCompletedCallback(string taskId, bool isError)
        {
            // Do post background work here.
            // Cleanup the thread and task object references, etc.
        }
    }
    /// <summary>
    /// ThreadTask defines the work a thread needs to do and also provides any data 
    /// required along with callback pointers etc.
    /// Populate a new ThreadTask instance with any data the thread needs 
    /// then start the thread to execute the task.
    /// </summary>
    internal class SomeThreadTask
    {
        private string _taskId;
        private SomeThreadTaskCompleted _completedCallback;
        /// <summary>
        /// Get. Set simple identifier that allows main thread to identify this task.
        /// </summary>
        internal string TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }
        /// <summary>
        /// Get, Set instance of a delegate used to notify the main thread when done.
        /// </summary>
        internal SomeThreadTaskCompleted CompletedCallback
        {
            get { return _completedCallback; }
            set { _completedCallback = value; }
        }
        /// <summary>
        /// Thread entry point function.
        /// </summary>
        internal void ExecuteThreadTask()
        {
            // Often a good idea to tell the main thread if there was an error
            bool isError = false;
            // Thread begins execution here.
            
            // You would start some kind of long task here 
            // such as image processing, file parsing, complex query, etc.
            // Thread execution eventually returns to this function when complete.
            // Execute callback to tell main thread this task is done.
            _completedCallback.Invoke(_taskId, isError);
        }
    }
    }
