    Action action = new Action(() =>
                {
                    lock (_messagesLock)
                    {
                        _messages.Remove(message);
                    }
                });
                _dispatcher.Invoke(DispatcherPriority.Normal, action);
