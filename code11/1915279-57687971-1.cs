    public interface ISchedulerDefaults
    {
        IScheduler AsyncConversions { get; }
        IScheduler ConstantTimeOperations { get; }
        IScheduler Iteration { get; }
        IScheduler TailRecursion { get; }
        IScheduler TimeBasedOperations { get; }
    }
and reference that instead `services.AddSingleton<ISchedulerDefaults, SchedulerDefaults>();`
For your unit tests you can use:
    public class TestSchedulerDefaults : ISchedulerDefaults
    {
        public IScheduler AsyncConversions => new TestScheduler();
        public IScheduler ConstantTimeOperations => new TestScheduler();
        public IScheduler Iteration => new TestScheduler();
        public IScheduler TailRecursion => new TestScheduler();
        public IScheduler TimeBasedOperations => new TestScheduler();
    }
