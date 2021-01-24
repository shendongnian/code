    public interface ISchedulerDefaults
    {
        IScheduler AsyncConversions { get; }
        IScheduler ConstantTimeOperations { get; }
        IScheduler Iteration { get; }
        IScheduler TailRecursion { get; }
        IScheduler TimeBasedOperations { get; }
    }
and reference that instead `services.AddSingleton<ISchedulerDefaults, SchedulerDefaults>();`
