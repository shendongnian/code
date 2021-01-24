      protected virtual async void RunSynchronizeTask()
            {
                var cancelationToken = new CancellationToken();
                App.TaskToDisposeTokens.Add(cancelationToken);
                await Task.Run(() =>
                {
                    try { 
                    while (true)
                    {
                        Thread.Sleep(RefreshTime);
                        if (DateTime.Now.TimeOfDay - LastSyncrhonization.TimeOfDay > RefreshTime)
                        {
                            Application.Current.Dispatcher.Invoke(delegate
                            {
                                GetDataAndRefreshUI();
                            });
                            LastSyncrhonization = DateTime.Now;
                        }
                    }
                    }
                    catch(OperationCanceledException) { }
                }, cancelationToken);
    
            }
