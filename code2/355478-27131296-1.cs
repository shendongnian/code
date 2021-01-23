The benefit of async is the calling method can invoke several blocking operations in parallel and only block once the returned value is needed. This same capability is possible in this scenario with yield/return by using return type IEnumerable&lt;Task&gt;.
    public IEnumerable<Task<File>> DownloadPictures() {
        const string format = "http://example.com/files/{0}.png";
        for (int i = 0; i++; ) {
            yield return DownloadFileAsync(string.Format(format, i));
        }
    }
In a similar fashion to async/await the calling method can now continue to execute until it needs the next value at which point await/.Result can be called on the next task. The following extension method demonstrates this:
        public static IEnumerable<T> Results<T>(this IEnumerable<Task<T>> tasks)
        {
            foreach (var task in tasks)
                yield return task.Result;
        }
If the calling method would like to ensure that all the IEnumerable Tasks are created and running in parallel then an extension method such as the following may be beneficial (this, and the aforementioned method, are likely already in a standard lib):
        public static IEnumerable<T> ResultsParallel<T>(this IEnumerable<Task<T>> tasks)
        {
            foreach (var task in tasks.ToArray())
                yield return task.Result;
        }
Notice how the responsibility for the concern of what runs in parallel is transferred to the calling method just as it was with async/await. In the event that there is concern regarding the creation of the Tasks blocking, an extension method such as the following could be created:
        public static Task<IEnumerable<T>> ResultsAsync<T>(this IEnumerable<Task<T>> tasks)
        {
            var startedTasks = new ConcurrentQueue<Task<T>>();
            var writerTask = new Task(() =>
                {
                    foreach (var task in tasks)
                    {
                        startedTasks.Enqueue(task);
                    }
                });
            writerTask.Start();
            var readerTask = new Task<IEnumerable<T>>(() =>
            {
                return ResultsSequential(startedTasks, () => writerTask.IsCompleted);
            });
            readerTask.Start();
            return readerTask;
        }
        private static IEnumerable<T> ResultsSequential<T>(ConcurrentQueue<Task<T>> tasks, Func<bool> isDone)
        {
            while (true)
            {
                Task<T> task;
                if (isDone.Invoke())
                {
                    if (tasks.TryDequeue(out task))
                    {
                        yield return task.Result;
                    }
                    else
                    {
                        yield break;
                    }
                } else if (tasks.TryDequeue(out task))
                {
                    yield return task.Result;
                }
            }
        }
