    public class ActionTaskBlock<TRequest, TResponse>
    {
        private readonly ActionBlock<(TRequest,
            TaskCompletionSource<TResponse>)> _actionBlock;
        /// <summary>Initializes a new instance of the
        /// <see cref="ActionTaskBlock{TRequest,TResponse}"/> class with the
        /// specified process delegate, cancellation token, and max degree of
        /// parallelism.</summary>
        public ActionTaskBlock(Func<TRequest, CancellationToken, TResponse> process,
            CancellationToken cancellationToken, int maxDegreeOfParallelism)
        {
            _actionBlock = new ActionBlock<
                (TRequest Request, TaskCompletionSource<TResponse> TCS)>(entry =>
            {
                try
                {
                    var response = process(entry.Request, cancellationToken);
                    entry.TCS.SetResult(response);
                }
                catch (OperationCanceledException)
                {
                    entry.TCS.TrySetCanceled();
                }
                catch (Exception ex)
                {
                    entry.TCS.TrySetException(ex);
                }
            }, new ExecutionDataflowBlockOptions()
            {
                CancellationToken = cancellationToken,
                MaxDegreeOfParallelism = maxDegreeOfParallelism,
            });
        }
        /// <summary>Signals to the block that it shouldn't accept any more
        /// requests.</summary>
        public void Complete() => _actionBlock.Complete();
        /// <summary>Gets a <see cref="Task"/> object that represents the
        /// asynchronous operation and completion of the block.</summary>
        public Task Completion => _actionBlock.Completion;
        /// <summary>Schedules a <typeparamref name="TRequest"/> for processing
        /// by the block.</summary>
        public async Task<TResponse> ProcessAsync(TRequest request)
        {
            var tsc = new TaskCompletionSource<TResponse>(
                TaskCreationOptions.RunContinuationsAsynchronously);
            await _actionBlock.SendAsync((request, tsc)).ConfigureAwait(false);
            return await tsc.Task.ConfigureAwait(false);
        }
    }
