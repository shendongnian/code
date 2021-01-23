     public class ParallelExcecuter
    {
        private readonly BlockingCollection<Task> _workItemHolder;
        public ParallelExcecuter(int maxDegreeOfParallelism)
        {
            _workItemHolder = new BlockingCollection<Task>(maxDegreeOfParallelism);
        }
        public void Submit(Action action)
        {
            _workItemHolder.Add(Task.Run(action).ContinueWith(t =>
            {
                _workItemHolder.Take();
            })
             );
        }
        public void WaitUntilWorkDone()
        {
            while (_workItemHolder.Count < 0)
            {
                Monitor.Wait(_workItemHolder);
            }
        }
    }
