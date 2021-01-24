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
    public sealed class TestSchedulerDefaults : ISchedulerDefaults
    {
        private readonly TestScheduler _timeBasedOperations = new TestScheduler();
        private readonly TestScheduler _asyncConversions = new TestScheduler();
        private readonly  TestScheduler _constantTimeOperations = new TestScheduler();
        private  readonly TestScheduler _iteration = new TestScheduler();
        private  readonly TestScheduler _tailRecursion = new TestScheduler();
        IScheduler ISchedulerDefaults.AsyncConversions => new TestScheduler();
        IScheduler ISchedulerDefaults.ConstantTimeOperations => new TestScheduler();
        IScheduler ISchedulerDefaults.Iteration => new TestScheduler();
        IScheduler ISchedulerDefaults.TailRecursion => new TestScheduler();
        IScheduler ISchedulerDefaults.TimeBasedOperations => _timeBasedOperations;
        public IScheduler AsyncConversions => _asyncConversions;
        public IScheduler ConstantTimeOperations => _constantTimeOperations;
        public IScheduler Iteration => _iteration;
        public IScheduler TailRecursion => _tailRecursion;
        public TestScheduler TimeBasedOperations => _timeBasedOperations;
    }
