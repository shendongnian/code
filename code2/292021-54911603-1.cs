    public class ExceptionPropagatingProgress<TProgress>
    {
        private readonly Action<TProgress> onProgressUpdateCore;
        private readonly IProgress<TProgress> progress;
        public Exception Exception { get; private set; }
        public ExceptionPropagatingProgress(Action<TProgress> handler)
        {
            this.Exception = null;
            this.onProgressUpdateCore = handler ?? throw new ArgumentNullException(nameof(handler));
            this.progress = new Progress<TProgress>(this.OnProgressUpdate);
        }
        public void End()
        {
            if (this.Exception != null)
            {
                throw new AggregateException(this.Exception);
            }
        }
        private void OnProgressUpdate(TProgress value)
        {
            try
            {
                this.onProgressUpdateCore(value);
            }
            catch (Exception exception)
            {
                lock (this.onProgressUpdateCore)
                {
                    if (this.Exception == null)
                    {
                        this.Exception = exception;
                    }
                    else
                    {
                        this.Exception = new AggregateException(this.Exception, exception);
                    }
                }
            }
        }
        public void QueueProgressUpdate(TProgress value)
        {
            if (this.Exception != null)
            {
                throw new AggregateException(this.Exception);
            }
            this.progress.Report(value);
        }
    }
