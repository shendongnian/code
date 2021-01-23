    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    ///     Provides a scheduler that uses STA threads.
    ///     Borrowed from Stephen Toub's implementation http://blogs.msdn.com/b/pfxteam/archive/2010/04/07/9990421.aspx
    /// </summary>
    public sealed class StaTaskScheduler : TaskScheduler, IDisposable
    {
        /// <summary>
        ///     The STA threads used by the scheduler.
        /// </summary>
        private readonly List<Thread> threads;
        /// <summary>
        ///     Stores the queued tasks to be executed by our pool of STA threads.
        /// </summary>
        private BlockingCollection<Task> tasks;
        /// <summary>
        ///     Initializes a new instance of the StaTaskScheduler class with the specified concurrency level.
        /// </summary>
        /// <param name = "numberOfThreads">The number of threads that should be created and used by this scheduler.</param>
        public StaTaskScheduler(int numberOfThreads)
        {
            if (numberOfThreads < 1)
            {
                throw new ArgumentOutOfRangeException(
                    "numberOfThreads", "The scheduler must create at least one thread");
            }
            // Initialize the tasks collection
            this.tasks = new BlockingCollection<Task>();
            // Create the threads to be used by this scheduler
            this.threads = Enumerable.Range(0, numberOfThreads).Select(
                i =>
                    {
                        var thread = new Thread(
                            () =>
                                {
                                    // Continually get the next task and try to execute it.
                                    // This will continue until the scheduler is disposed and no more tasks remain.
                                    foreach (Task t in this.tasks.GetConsumingEnumerable())
                                    {
                                        this.TryExecuteTask(t);
                                    }
                                }) {
                                      Name = "Sta Thread", IsBackground = true 
                                   };
                        thread.SetApartmentState(ApartmentState.STA);
                        return thread;
                    }).ToList();
            // Start all of the threads
            this.threads.ForEach(t => t.Start());
        }
        /// <summary>
        ///     Gets the maximum concurrency level supported by this scheduler.
        /// </summary>
        public override int MaximumConcurrencyLevel
        {
            get
            {
                return this.threads.Count;
            }
        }
        /// <summary>
        ///     Cleans up the scheduler by indicating that no more tasks will be queued.
        ///     This method blocks until all threads successfully shutdown.
        /// </summary>
        public void Dispose()
        {
            if (this.tasks != null)
            {
                // Indicate that no new tasks will be coming in
                this.tasks.CompleteAdding();
                // Wait for all threads to finish processing tasks
                foreach (Thread thread in this.threads)
                {
                    thread.Join();
                }
                // Cleanup
                this.tasks.Dispose();
                this.tasks = null;
            }
        }
        /// <summary>
        ///     Provides a list of the scheduled tasks for the debugger to consume.
        /// </summary>
        /// <returns>An enumerable of all tasks currently scheduled.</returns>
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            // Serialize the contents of the blocking collection of tasks for the debugger
            return this.tasks.ToArray();
        }
        /// <summary>
        ///     Queues a Task to be executed by this scheduler.
        /// </summary>
        /// <param name = "task">The task to be executed.</param>
        protected override void QueueTask(Task task)
        {
            // Push it into the blocking collection of tasks
            this.tasks.Add(task);
        }
        /// <summary>
        ///     Determines whether a Task may be inlined.
        /// </summary>
        /// <param name = "task">The task to be executed.</param>
        /// <param name = "taskWasPreviouslyQueued">Whether the task was previously queued.</param>
        /// <returns>true if the task was successfully inlined; otherwise, false.</returns>
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // Try to inline if the current thread is STA
            return Thread.CurrentThread.GetApartmentState() == ApartmentState.STA && this.TryExecuteTask(task);
        }
    }
