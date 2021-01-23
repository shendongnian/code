    Storages.ForEach(queue =>
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    LoggingManager.LogInfo("Starting a local thread to read in mime messages from queue " + queue.Name, this.GetType());
                    while (true)
                    {
                        WorkItem mime = queue.WaitAndRetrieve();
                        if (mime != null)
                        {
                            _Semaphore.WaitOne();
                            _LocalStorage.Enqueue(mime);
                            lock (_locker) Monitor.Pulse(_locker);
                            LoggingManager.LogDebug("Adding no. " + _LocalStorage.Count + " item in queue", this.GetType());
                        }
                    }
                });
            });
