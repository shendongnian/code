    sealed class PreFetch<T> : GraphStage<SourceShape<T>>
    {
        private readonly int threshold;
        private readonly Func<Task<IEnumerable<T>>> fetch;
        private readonly Outlet<T> outlet = new Outlet<T>("prefetch");
        public PreFetch(int threshold, Func<Task<IEnumerable<T>>> fetch)
        {
            this.threshold = threshold;
            this.fetch = fetch;
            this.Shape = new SourceShape<T>(this.outlet);
        }
        public override SourceShape<T> Shape { get; }
        protected override GraphStageLogic CreateLogic(Attributes inheritedAttributes) => new Logic(this);
        private sealed class Logic : GraphStageLogic
        {
            public Logic(PreFetch<T> stage) : base(stage.Shape)
            {
                // queue for batched elements
                var queue = new Queue<T>();
                // flag which indicates, that pull from downstream was made, 
                // but we didn't have any elements at that moment
                var wasPulled = false;
                // determines if fetch was already called
                var fetchInProgress = false;
                // in order to cooperate with async calls without data races, 
                // we need to register async callbacks for success and failure scenarios
                var onSuccess = this.GetAsyncCallback<IEnumerable<T>>(batch =>
                {
                    foreach (var item in batch) queue.Enqueue(item);
                    if (wasPulled)
                    {
                        // if pull was requested but not fulfilled, we need to push now, as we have elements
                        // it assumes that fetch returned non-empty batch
                        Push(stage.outlet, queue.Dequeue());
                        wasPulled = false;
                    }
                    fetchInProgress = false;
                });
                var onFailure = this.GetAsyncCallback<Exception>(this.FailStage);
                SetHandler(stage.outlet, onPull: () => {
                    if (queue.Count < stage.threshold && !fetchInProgress)
                    {
                        // if queue occupation reached bellow expected capacity
                        // call fetch on a side thread and handle its result asynchronously
                        stage.fetch().ContinueWith(task =>
                        {
                            // depending on if task was failed or not, we call corresponding callback
                            if (task.IsFaulted || task.IsCanceled)
                                onFailure(task.Exception as Exception ?? new TaskCanceledException(task));
                            else onSuccess(task.Result);
                        });
                        fetchInProgress = true;
                    }
                    // if queue is empty, we cannot push immediatelly, so we only mark 
                    // that pull request has been made but not fulfilled
                    if (queue.Count == 0)
                        wasPulled = true;
                    else
                    {
                        Push(stage.outlet, queue.Dequeue());
                        wasPulled = false;
                    }
                });
            }
        }
    }
