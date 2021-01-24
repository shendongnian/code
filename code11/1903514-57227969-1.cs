`
        public class Worker
        {
            public Worker(int workerId, CancellationToken ct, int howMuchWorkToDo)
            {
                this.WorkerId = workerId;
                this.CancellationToken = ct;
                this.ToDo = howMuchWorkToDo;
                this.Done = 0;
            }
            public int WorkerId { get; }
            public CancellationToken CancellationToken { get; }
            public int ToDo { get; }
            public int Done { get; set; }
            static MethodLock MethodLock { get; } = new MethodLock();
            public async Task DoWorkAwareAsync()
            {
                this.CancellationToken.ThrowIfCancellationRequested();
                this.Done = 0;
                while (this.Done < this.ToDo) {
                    await this.UseCriticalResourceAsync();
                    await this.OtherWorkAsync();
                    this.CancellationToken.ThrowIfCancellationRequested();
                    this.Done += 1;
                }
                Console.WriteLine($"Worker {this.WorkerId} completed {this.Done} out of {this.ToDo}");
            }
            private async Task UseCriticalResourceAsync()
            {
                using (await MethodLock.LockAsync()) {
                    //Console.WriteLine($"Worker {this.WorkerId} acquired lock on critical resource.");
                    await Task.Delay(TimeSpan.FromMilliseconds(50));
                }
            }
            private async Task OtherWorkAsync()
            {
                await Task.Delay(TimeSpan.FromMilliseconds(50));
            }
        }
`
Now let's look at how to start a number of background workers and keep them from running too long, i.e. cancelling them after a few seconds. Note this is set up as a console application.
The tasks are put onto the thread pool, which means that the system will allocate the tasks among available threads. The system can also dynamically reallocate the tasks to threads if needed, for example if a task is queued to a thread that is busy while another thread becomes free.  
`
        static void Main(string[] args)
        {
            Random rand = new Random( DateTime.Now.Millisecond);
            Console.WriteLine("---- Cancellation-aware work");
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++) {
                CancellationTokenSource cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromMilliseconds(2000));
                int howMuchWork = (rand.Next() % 10) + 1;
                Worker w = new Worker(i, cts.Token, howMuchWork);
                tasks[i] = Task.Run(
                    async () => {
                        try {
                            await w.DoWorkAwareAsync();
                        } catch (OperationCanceledException) {
                            Console.WriteLine($"Canceled worker {w.WorkerId}, work done was {w.Done} out of {w.ToDo}");
                        }
                    },
                    cts.Token
                );
            }
            try {
                Task.WaitAll(tasks);
            } catch (AggregateException ae) {
                foreach (Exception e in ae.InnerExceptions) {
                    Console.WriteLine($"Exception occurred during work: {e.Message}");
                }
            }
            Console.ReadKey();
        }
`
I would comment that the presence of "cts.Token" as the second argument to Task.Run does NOT relate to a forced / hard cancellation of the task created by the Task.Run method. All that Task.Run does with this second argument is compare it to the cancellation token inside the cancellation exception, and if it is the same then Task.Run transitions the task to the Canceled state.  
When you run this you'll see something like the following: 
`
    ---- Cancellation-aware work
    Worker 5 completed 1 out of 1
    Worker 2 completed 1 out of 1
    Worker 8 completed 1 out of 1
    Worker 6 completed 3 out of 3
    Worker 7 completed 3 out of 3
    Canceled worker 3, work done was 4 out of 5
    Canceled worker 4, work done was 4 out of 10
    Canceled worker 1, work done was 4 out of 8
    Canceled worker 9, work done was 4 out of 7
    Canceled worker 0, work done was 5 out of 9
`
Again, this design assumes that the worker methods cooperate with the cancellation. If you are working with legacy code where the worker operation does not cooperate in listening for cancellation requests then it may be necessary to create a thread for that worker operation. This requires proper cleanup and in addition it can create performance problems because it uses up threads, which are a limited resource. The response by Simon Mourier in the middle of this linked discussion shows how to do it: https://stackoverflow.com/questions/4359910/is-it-possible-to-abort-a-task-like-aborting-a-thread-thread-abort-method 
