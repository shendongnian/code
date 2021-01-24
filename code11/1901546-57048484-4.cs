    class MyTaskFactory : IMyTaskFactory
    {
        private readonly ISingletonA _singletonA;
        private readonly ISingletonB _singletonB;
        public MyTaskFactory(ISingletonA singletonA, ISingletonB singletonB)
        {
            _singletonA = singletonA;
            _singletonB = singletonB;
        }
        public T Resolve<T>() where T : ITask
        {
            if (typeof(T) == typeof(TaskA)) return (T)(object)GetTaskA();
            if (typeof(T) == typeof(TaskB)) return (T)(object)GetTaskB();
            if (typeof(T) == typeof(TaskC)) return (T)(object)GetTaskC();
			
			throw new ArgumentException(string.Format("Type not supported: {0}", typeof(T).FullName));
        }
        protected TaskA GetTaskA()
        {
            return new TaskA(_singletonA);
        }
        protected TaskB GetTaskB()
        {
            return new TaskB(_singletonA, _singletonB);
        }
        protected TaskC GetTaskC()
        {
            return new TaskC(_singletonA, "Other runtime parameter");
        }
    }
    public class Scheduler
    {
        protected readonly IMyTaskFactory _taskFactory;
        public Scheduler(IMyTaskFactory taskFactory)
        {
            _taskFactory = taskFactory;
        }
    
        public void Start()
        {
            var taskA = _taskFactory.Resolve<TaskA>();
            var taskB = _taskFactory.Resolve<TaskB>();
            var taskC = _taskFactory.Resolve<TaskC>();
        }
    }
