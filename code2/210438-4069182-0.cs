        public static IList<IAsyncResult> RunAsync<T>(IEnumerable<Func<T>> tasks)
        {
            List<IAsyncResult> asyncContext = new List<IAsyncResult>();
            foreach (var task in tasks)
            {
                asyncContext.Add(task.BeginInvoke(null, null));
            }
            return asyncContext;
        }
        public static IEnumerable<T> WaitForAll<T>(IEnumerable<Func<T>> tasks, IEnumerable<IAsyncResult> asyncContext)
        {
            IEnumerator<IAsyncResult> iterator = asyncContext.GetEnumerator();
            foreach (var task in tasks)
            {
                iterator.MoveNext();
                yield return task.EndInvoke(iterator.Current);
            }
        }
        public static void Main()
        {
            var tasks = Enumerable.Repeat<Func<int>>(() => ComputeValue(), 10).ToList();
            var asyncContext = RunAsync(tasks);
            var results = WaitForAll(tasks, asyncContext);
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
