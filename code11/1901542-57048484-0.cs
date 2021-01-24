    interface ITask {}
    interface TaskA : ITask {}
    interface TaskB : ITask {}
    interface TaskC : ITask {}
    public class MyTaskFactory : IMyTaskFactory
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
            return (T)Activator.CreateInstance
            (
                typeof(T), 
                new [] { _singletonA, _singletonB }
            );
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
