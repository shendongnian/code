    public abstract class LongTaskController: Controller,IHasLongTask
    {
        private bool _hasLongTask;
        public bool HasLongTask { get { return _hasLongTask; } }
        public event EventHandler CompleteLongTask;
        void IHasLongTask.DoLongTask(Action action) { DoLongTask(action); }
        protected void DoLongTask(Action action)
        {
            _hasLongTask = true;
            if (CompleteLongTask == null)
            {
                throw new NullReferenceException("Controller.CompleteLongTask cannot be null when Controller does a long running task.");
                action += () => CompleteLongTask(this, EventArgs.Empty);
            }
            new Task(action).Start();
        }
    }
    public interface IHasLongTask
    {
        bool HasLongTask { get; }
        void DoLongTask(Action action);
        event EventHandler CompleteLongTask;
    }
