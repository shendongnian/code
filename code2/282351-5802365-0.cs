    var parent = Task.Factory.StartNew(() =>
                {
                    var tasksI = Task.Factory.StartNew(() =>
                    {
                        for (int i = 0; i < Constants.TaskCount; i++)
                            DoMethod1Parallel();
                       
                    });
    
                    var tasksII = Task.Factory.StartNew(() =>
                    {
                        for (int i = 0; i < Constants.TaskCount; i++)
                            DoMethod2Parallel()
    
                    });
    
                    tasksI .Wait();
                    tasksII.Wait();
                });
    
                parent.Wait();
                Assert.AreNotEqual(parent.IsFaulted, "Executing is faulted!");
