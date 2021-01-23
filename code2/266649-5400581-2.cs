        public abstract class AsyncCommandBase<TRequest, TResponse, TCorrelation> : IAsyncCommand<TRequest, TResponse, TCorrelation>
    {
        protected AsyncOperation operation = null;
        protected BackgroundWorker worker = null;
        #region IAsyncCommand<TRequest,TResponse,TCorrelation> Members
			//Implement all the interface members as per your use....
        #endregion
        protected void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Execute((TRequest)e.Argument);
        }
        protected void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgressChanged(e);
        }
        protected void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnCompleted(e);
        }
        protected void ReportProgress(int percentageProgress, string message)
        {
            if (worker != null && worker.WorkerReportsProgress)
                worker.ReportProgress(percentageProgress, message);
            else
                OnProgressChanged(new ProgressChangedEventArgs(percentageProgress, message));
        }
        protected void OnProgressChanged(ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
            {
                SendOrPostCallback callback = new SendOrPostCallback(delegate { ProgressChanged(this, new CommandProgressChangedEventArgs<string, TCorrelation>(e.ProgressPercentage, e.UserState as string, (TCorrelation)operation.UserSuppliedState)); });
                operation.Post(callback, null);
            }
        }
        protected void OnCompleted(RunWorkerCompletedEventArgs e)
        {
            if (Completed != null)
            {
                TResponse response = default(TResponse);
                if (e.Error == null)
                    response = (TResponse)e.Result;
                SendOrPostCallback callback = new SendOrPostCallback(delegate { Completed(this, new CommandCompletedEventArgs<TResponse, TCorrelation>(response, e.Error, (TCorrelation)operation.UserSuppliedState, e.Cancelled)); });
                operation.PostOperationCompleted(callback, null);
            }
        }
    }
