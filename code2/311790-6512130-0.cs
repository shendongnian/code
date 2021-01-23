            private void FireAndForget(Action fire)
            {
                _firedEvents.Enqueue(fire);
                lock (_taskLock)
                {
                    if (_launcherTask == null)
                    {
                        _launcherTask = new Task(LaunchEvents);
                        _launcherTask.ContinueWith(EventsComplete);
                        _launcherTask.Start();
                    }
                }
            }
            private void LaunchEvents()
            {
                Action nextEvent;
                while (_firedEvents.TryDequeue(out nextEvent))
                {
                    if (_synchronized)
                    {
                        var syncEvent = nextEvent;
                        _mediator._syncContext.Send(state => syncEvent(), null);
                    }
                    else
                    {
                        nextEvent();                        
                    }
                    lock (_taskLock)
                    {
                        if (_firedEvents.Count == 0)
                        {
                            _launcherTask = null;
                            break;
                        }
                    }
                }
            }
            private void EventsComplete(Task task)
            {
                if (task.IsFaulted && task.Exception != null)
                {
                     // Do something with task Exception here
                }
            }
