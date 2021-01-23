    interface ITask
    {
        void Execute(ITaskCallBack callBack, DateTime currentTime);
    }
    interface ITaskCallBack
    {
        void OnCompleted(ITask task); // The task parameter is needed for concurrency
    }
