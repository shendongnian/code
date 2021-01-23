    public interface ITaskExecuter
    {
        void ScheduleTask(
            Action executeAction,
            Action postExecuteAction,
            Action<Exception> onException);
    }
