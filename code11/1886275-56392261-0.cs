    void TestA()
    {
        Task taskA = null;
        try
        {
            // start a task without awaiting
            taskA = DoSomethingAsync();
            // perform your test
            ...
            // wait until taskA completes
            taskA.Wait();
            // check the result of taskA
            ...
         }
         catch (Exception exc)
         {
             ...
         }
         finally
         {
             // make sure that even if exception TaskA completes
             taskA.Wait();
         }
     }
