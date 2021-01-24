    public static class WhenAnyExtension {
        /// <summary>
        /// Continues on first successful task, throw exception if all tasks fail
        /// </summary>
        /// <typeparam name="TResult">The type of task result</typeparam>
        /// <param name="tasks">An IEnumerable<T> to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The first result in the sequence that passes the test in the specified predicate function.</returns>
        public static async Task<TResult> WhenFirst<TResult>(this IEnumerable<Task<TResult>> tasks, Func<TResult, bool> predicate, CancellationToken cancellationToken = default(CancellationToken)) {
            var running = tasks.ToList();
            var taskCount = running.Count;
            var failCount = 0;
            var result = default(TResult);
            while (running.Count > 0) {
                if (cancellationToken.IsCancellationRequested) {
                    result = await Task.FromCanceled<TResult>(cancellationToken);
                    break;
                }
                var finished = await Task.WhenAny(running);
                running.Remove(finished);
                result = await finished;
                if (predicate(result)) {
                    break;
                }
                failCount++;
            }
            // If none of them succeed, throw exception; 
            if (failCount == taskCount)
                throw new InvalidOperationException("No task result satisfies the condition in predicate");
            return result;
        }
    }
