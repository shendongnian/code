            /// <summary>
            /// Simulate doing work
            /// </summary>
            private void DoWork()
            {
                try
                {
                    for (int i = 0; i < m_RecordCount; i++)
                    {
                        //Sleep for 100 miliseconds to simulate work
                        Thread.Sleep(100);
     
                        //increment the progress bar by invoking it on the main window thread
                        progressBar.Invoke(
                            (MethodInvoker)
                            delegate
                            {
                                //Increment the progress bar
                                progressBar.Increment(1);
                            }
                        );
                    }
     
                    //Join the thread
                    Thread.CurrentThread.Join(0);
                }
                catch (Exception)
                {
                    throw;
                }
            }
