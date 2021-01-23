    public static TaskScheduler Current
    {
        get
        {
            Task internalCurrent = Task.InternalCurrent;
            if (internalCurrent != null)
            {
                return internalCurrent.ExecutingTaskScheduler;
            }
            return Default;
        }
    }
