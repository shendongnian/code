    /// <summary>
    ///     Asynchronous version of <see cref="ManualResetEvent" />
    /// </summary>
    public sealed class ManualResetEventAsync
    {
        /// <summary>
        /// The task completion source.
        /// </summary>
        private volatile TaskCompletionSource<bool> taskCompletionSource =
            new TaskCompletionSource<bool>();
        /// <summary>
        /// Initializes a new instance of the <see cref="ManualResetEventAsync"/>
        /// class with a <see cref="bool"/> value indicating whether to set the
        /// initial state to signaled.
        /// </summary>
        /// <param name="initialState">
        /// True to set the initial state to signaled; false to set the initial
        /// state to non-signaled.
        /// </param>
        public ManualResetEventAsync(bool initialState)
        {
            if (initialState)
            {
                this.Set();
            }
        }
        /// <summary>
        /// Return a task that can be consumed by <see cref="Task.Wait()"/>
        /// </summary>
        /// <returns>
        /// The asynchronous waiter.
        /// </returns>
        public Task GetWaitTask()
        {
            return this.taskCompletionSource.Task;
        }
        /// <summary>
        /// Mark the event as signaled.
        /// </summary>
        public void Set()
        {
            var tcs = this.taskCompletionSource;
            Task.Factory.StartNew(
                s => ((TaskCompletionSource<bool>)s).TrySetResult(true),
                tcs,
                CancellationToken.None,
                TaskCreationOptions.PreferFairness,
                TaskScheduler.Default);
            tcs.Task.Wait();
        }
        /// <summary>
        /// Mark the event as not signaled.
        /// </summary>
        public void Reset()
        {
            while (true)
            {
                var tcs = this.taskCompletionSource;
                if (!tcs.Task.IsCompleted
    #pragma warning disable 420
                    || Interlocked.CompareExchange(
                        ref this.taskCompletionSource,
                        new TaskCompletionSource<bool>(),
                        tcs) == tcs)
    #pragma warning restore 420
                {
                    return;
                }
            }
        }
        /// <summary>
        /// Waits for the <see cref="ManualResetEventAsync"/> to be signaled.
        /// </summary>
        /// <exception cref="T:System.AggregateException">
        /// The <see cref="ManualResetEventAsync"/> waiting <see cref="Task"/>
        /// was canceled -or- an exception was thrown during the execution
        /// of the <see cref="ManualResetEventAsync"/> waiting <see cref="Task"/>.
        /// </exception>
        public void Wait()
        {
            this.GetWaitTask().Wait();
        }
        /// <summary>
        /// Waits for the <see cref="ManualResetEventAsync"/> to be signaled.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for
        /// the task to complete.
        /// </param>
        /// <exception cref="T:System.OperationCanceledException">
        /// The <paramref name="cancellationToken"/> was canceled.
        /// </exception>
        /// <exception cref="T:System.AggregateException">
        /// The <see cref="ManualResetEventAsync"/> waiting <see cref="Task"/> was
        /// canceled -or- an exception was thrown during the execution of the
        /// <see cref="ManualResetEventAsync"/> waiting <see cref="Task"/>.
        /// </exception>
        public void Wait(CancellationToken cancellationToken)
        {
            this.GetWaitTask().Wait(cancellationToken);
        }
        /// <summary>
        /// Waits for the <see cref="ManualResetEventAsync"/> to be signaled.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for
        /// the task to complete.
        /// </param>
        /// <param name="canceled">
        /// Set to true if the wait was canceled via the <paramref
        /// name="cancellationToken"/>.
        /// </param>
        public void Wait(CancellationToken cancellationToken, out bool canceled)
        {
            try
            {
                this.GetWaitTask().Wait(cancellationToken);
                canceled = false;
            }
            catch (Exception ex)
                when (ex is OperationCanceledException
                    || (ex is AggregateException
                        && ex.InnerOf<OperationCanceledException>() != null))
            {
                canceled = true;
            }
        }
        /// <summary>
        /// Waits for the <see cref="ManualResetEventAsync"/> to be signaled.
        /// </summary>
        /// <param name="timeout">
        /// A <see cref="System.TimeSpan"/> that represents the number of
        /// milliseconds to wait, or a <see cref="System.TimeSpan"/> that
        /// represents -1 milliseconds to wait indefinitely.
        /// </param>
        /// <returns>
        /// true if the <see cref="ManualResetEventAsync"/> was signaled within
        /// the allotted time; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="timeout"/> is a negative number other than -1
        /// milliseconds, which represents an infinite time-out -or-
        /// timeout is greater than <see cref="int.MaxValue"/>.
        /// </exception>
        public bool Wait(TimeSpan timeout)
        {
            return this.GetWaitTask().Wait(timeout);
        }
        /// <summary>
        /// Waits for the <see cref="ManualResetEventAsync"/> to be signaled.
        /// </summary>
        /// <param name="millisecondsTimeout">
        /// The number of milliseconds to wait, or
        /// <see cref="System.Threading.Timeout.Infinite"/> (-1) to wait
        /// indefinitely.
        /// </param>
        /// <returns>
        /// true if the <see cref="ManualResetEventAsync"/> was signaled within
        /// the allotted time; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="millisecondsTimeout"/> is a negative number other
        /// than -1, which represents an infinite time-out.
        /// </exception>
        public bool Wait(int millisecondsTimeout)
        {
            return this.GetWaitTask().Wait(millisecondsTimeout);
        }
        /// <summary>
        /// Waits for the <see cref="ManualResetEventAsync"/> to be signaled.
        /// </summary>
        /// <param name="millisecondsTimeout">
        /// The number of milliseconds to wait, or
        /// <see cref="System.Threading.Timeout.Infinite"/> (-1) to wait
        /// indefinitely.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for the
        /// <see cref="ManualResetEventAsync"/> to be signaled.
        /// </param>
        /// <returns>
        /// true if the <see cref="ManualResetEventAsync"/> was signaled within
        /// the allotted time; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.AggregateException">
        /// The <see cref="ManualResetEventAsync"/> waiting <see cref="Task"/>
        /// was canceled -or- an exception was thrown during the execution of
        /// the <see cref="ManualResetEventAsync"/> waiting <see cref="Task"/>.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="millisecondsTimeout"/> is a negative number other
        /// than -1, which represents an infinite time-out.
        /// </exception>
        /// <exception cref="T:System.OperationCanceledException">
        /// The <paramref name="cancellationToken"/> was canceled.
        /// </exception>
        public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken)
        {
            return this.GetWaitTask().Wait(millisecondsTimeout, cancellationToken);
        }
        /// <summary>
        /// Waits for the <see cref="ManualResetEventAsync"/> to be signaled.
        /// </summary>
        /// <param name="millisecondsTimeout">
        /// The number of milliseconds to wait, or
        /// <see cref="System.Threading.Timeout.Infinite"/> (-1) to wait
        /// indefinitely.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for the
        /// <see cref="ManualResetEventAsync"/> to be signaled.
        /// </param>
        /// <param name="canceled">
        /// Set to true if the wait was canceled via the <paramref
        /// name="cancellationToken"/>.
        /// </param>
        /// <returns>
        /// true if the <see cref="ManualResetEventAsync"/> was signaled within
        /// the allotted time; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="millisecondsTimeout"/> is a negative number other
        /// than -1, which represents an infinite time-out.
        /// </exception>
        public bool Wait(
            int millisecondsTimeout,
            CancellationToken cancellationToken,
            out bool canceled)
        {
            bool ret = false;
            try
            {
                ret = this.GetWaitTask().Wait(millisecondsTimeout, cancellationToken);
                canceled = false;
            }
            catch (Exception ex)
                when (ex is OperationCanceledException
                    || (ex is AggregateException
                        && ex.InnerOf<OperationCanceledException>() != null))
            {
                canceled = true;
            }
            return ret;
        }
    }
