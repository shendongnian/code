            private void Go()
            {
                ThreadStart start = delegate()
                {
                    //this is taking place on the background thread
                    for (int i = 0; i < 100; i++)
                    {
                        //this is slowing things down; no real relevance
                        Thread.Sleep(100);
                        //this will marshal us back to the UI thread
                        Dispatcher.Invoke(DispatcherPriority.Normal,
                                             new Action<int>(Update), i
                                             );
                    }
    
                };
    
                new Thread(start).Start();
            }
    
            void Update(int value)
            {
                //this is taking place on the UI thread
                _progressBar.Value = value;
            }
