    public static void ThrowFirstExceptionIfHappens(this Task task)
    {
        task.ContinueWith(t =>
        {
            var aggException = t.Exception.Flatten();
            foreach (var exception in aggException.InnerExceptions)
            {
                throw exception; // throw only first, search for solution
            }
        },
        TaskContinuationOptions.OnlyOnFaulted); // not valid for multi task continuations
    }
    public static Task CreateHandledTask(Action action) 
    {
        Task tsk = Task.Factory.StartNew(action);
        tsk.ThrowFirstExceptionIfHappens();
        return tsk;
    }
