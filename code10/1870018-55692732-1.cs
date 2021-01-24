        public static Task UnwrapAggregateException(this Task taskToUnwrap)
        {
            var tcs = new TaskCompletionSource<bool>();
            taskToUnwrap.ContinueWith(task =>
            {
                if (task.IsCanceled)
                    tcs.SetCanceled();
                else if (task.IsFaulted)
                {
                    if (task.Exception is AggregateException aggregateException)
                        tcs.SetException(Flatten(aggregateException));
                    else
                        tcs.SetException(task.Exception);
                }
                else //successful
                    tcs.SetResult(true);
            });
            IEnumerable<Exception> Flatten(AggregateException exception)
            {
                var stack = new Stack<AggregateException>();
                stack.Push(exception);
                while (stack.Any())
                {
                    var next = stack.Pop();
                    foreach (Exception inner in next.InnerExceptions)
                    {
                        if (inner is AggregateException innerAggregate)
                            stack.Push(innerAggregate);
                        else
                            yield return inner;
                    }
                }
            }
            return tcs.Task;
        }
