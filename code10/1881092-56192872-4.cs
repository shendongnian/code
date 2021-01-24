    public class RecursiveTask<T1, T2>
    {
        private readonly Func<RecursiveTask<T1, T2>, T1, T2> _func;
        private readonly Dictionary<T1, RecursiveTask<T1, T2>> _allTasks;
        private readonly List<RecursiveTask<T1, T2>> _subTasks;
        private readonly RecursiveTask<T1, T2> _rootTask;
        private T1 _arg;
        private T2 _result;
        private int _runsCount;
        private bool _isCompleted;
        private bool _isEvaluating;
        private RecursiveTask(Func<RecursiveTask<T1, T2>, T1, T2> func)
        {
            _func = func;
            _allTasks = new Dictionary<T1, RecursiveTask<T1, T2>>();
            _subTasks = new List<RecursiveTask<T1, T2>>();
            _rootTask = this;
        }
        private RecursiveTask(Func<RecursiveTask<T1, T2>, T1, T2> func, T1 arg, RecursiveTask<T1, T2> rootTask) : this(func)
        {
            _arg = arg;
            _rootTask = rootTask;
        }
        public T2 Run(T1 arg)
        {
            if (!_isEvaluating)
                BuildTasks(arg);
            if (_isEvaluating)
                return EvaluateTasks(arg);
            return default;
        }
        public static RecursiveTask<T1, T2> Create(Func<RecursiveTask<T1, T2>, T1, T2> func)
        {
            return new RecursiveTask<T1, T2>(func);
        }
        private void AddSubTask(T1 arg)
        {
            if (!_allTasks.TryGetValue(arg, out RecursiveTask<T1, T2> subTask))
            {
                subTask = new RecursiveTask<T1, T2>(_func, arg, this);
                _allTasks.Add(arg, subTask);
                _subTasks.Add(subTask);
            }
        }
        private T2 Run()
        {
            if (!_isCompleted)
            {
                var runsCount = _rootTask._runsCount;
                _result = _func(_rootTask, _arg);
                _isCompleted = runsCount == _rootTask._runsCount;
            }
            return _result;
        }
        private void BuildTasks(T1 arg)
        {
            if (_runsCount++ == 0)
                _arg = arg;
            if (EqualityComparer<T1>.Default.Equals(_arg, arg))
            {
                Run();
                var processed = 0;
                var addedTasksCount = _subTasks.Count;
                while (processed < addedTasksCount)
                {
                    for (var i = processed; i < addedTasksCount; i++, processed++)
                        _subTasks[i].Run();
                    addedTasksCount = _subTasks.Count;
                }
                _isEvaluating = true;
            }
            else
                AddSubTask(arg);
        }
        private T2 EvaluateTasks(T1 arg)
        {
            if (EqualityComparer<T1>.Default.Equals(_arg, arg))
            {
                foreach (var task in Enumerable.Reverse(_subTasks))
                    task.Run();
                return Run();
            }
            else
            {
                if (_allTasks.TryGetValue(arg, out RecursiveTask<T1, T2> task))
                    return task._isCompleted ? task._result : task.Run();
                else
                    return default;
            }
        }
    }
