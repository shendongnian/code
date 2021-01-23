        public class Future<T>
        {
            public Future(Func<T> task)
            {
                Task = task;
                _asyncContext = task.BeginInvoke(null, null);
            }
            private IAsyncResult _asyncContext;
            public Func<T> Task { get; private set; }
            public T Result
            {
                get
                {
                    return Task.EndInvoke(_asyncContext);
                }
            }
            public bool IsCompleted
            {
                get { return _asyncContext.IsCompleted; }
            }
        }
        public static IList<Future<T>> RunAsync<T>(IEnumerable<Func<T>> tasks)
        {
            List<Future<T>> asyncContext = new List<Future<T>>();
            foreach (var task in tasks)
            {
                asyncContext.Add(new Future<T>(task));
            }
            return asyncContext;
        }
        public static IEnumerable<T> WaitForAll<T>(IEnumerable<Future<T>> futures)
        {
            foreach (var future in futures)
            {
                yield return future.Result;
            }
        }
        public static void Main()
        {
            var tasks = Enumerable.Repeat<Func<int>>(() => ComputeValue(), 10).ToList();
            var futures = RunAsync(tasks);
            var results = WaitForAll(futures);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
        public static int ComputeValue()
        {
            Thread.Sleep(1000);
            return Guid.NewGuid().ToByteArray().Sum(a => (int)a);
        }
