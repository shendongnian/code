    public static class QueuedXmlTransform
    {
        private const int MaxBatchSizeMB = 600;
        private const double MB = (1024 * 1024 * 1024);
        private static readonly object SyncObj = new object();
        private static readonly TaskQueue Tasks = new TaskQueue();
        private static readonly Action Join = () => { };
        private static double _CurrentBatchSizeMb;
        public static string Transform(string xsltPath, string xmlPath)
        {
            string tempPath = Path.GetTempFileName();
            using (AutoResetEvent transformedEvent = new AutoResetEvent(false))
            {
                Action transformTask = () =>
                {
                    MvpXslTransform transform = new MvpXslTransform();
                    transform.Load(xsltPath, new XsltSettings(true, false),
                        new XmlUrlResolver());
                    using (StreamWriter writer = new StreamWriter(tempPath))
                    using (XmlReader reader = XmlReader.Create(xmlPath))
                    {
                        transform.Transform(new XmlInput(reader), null,
                            new XmlOutput(writer));
                    }
                    transformedEvent.Set();
                };
                double fileSizeMb = new FileInfo(xmlPath).Length / MB;
                lock (SyncObj)
                {
                    if ((_CurrentBatchSizeMb += fileSizeMb) > MaxBatchSizeMB)
                    {
                        _CurrentBatchSizeMb = 0;
                        Tasks.Queue(isParallel: false, task: Join);
                    }
                    Tasks.Queue(isParallel: true, task: transformTask);
                }
                transformedEvent.WaitOne();
            }
            return tempPath;
        }
        private class TaskQueue
        {
            private readonly object _syncObj = new object();
            private readonly Queue<QTask> _tasks = new Queue<QTask>();
            private int _runningTaskCount;
            public void Queue(bool isParallel, Action task)
            {
                lock (_syncObj)
                {
                    _tasks.Enqueue(new QTask { IsParallel = isParallel, Task = task });
                }
                ProcessTaskQueue();
            }
            private void ProcessTaskQueue()
            {
                lock (_syncObj)
                {
                    if (_runningTaskCount != 0) return;
                    while (_tasks.Count > 0 && _tasks.Peek().IsParallel)
                    {
                        QTask parallelTask = _tasks.Dequeue();
                        QueueUserWorkItem(parallelTask);
                    }
                    if (_tasks.Count > 0 && _runningTaskCount == 0)
                    {
                        QTask serialTask = _tasks.Dequeue();
                        QueueUserWorkItem(serialTask);
                    }
                }
            }
            private void QueueUserWorkItem(QTask qTask)
            {
                Action completionTask = () =>
                {
                    qTask.Task();
                    OnTaskCompleted();
                };
                _runningTaskCount++;
                ThreadPool.QueueUserWorkItem(_ => completionTask());
            }
            private void OnTaskCompleted()
            {
                lock (_syncObj)
                {
                    if (--_runningTaskCount == 0)
                    {
                        ProcessTaskQueue();
                    }
                }
            }
            private class QTask
            {
                public Action Task { get; set; }
                public bool IsParallel { get; set; }
            }
        }
    }
