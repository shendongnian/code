    [TestMethod]
    public void Test()
    {
      using (ActionThread thread = new ActionThread())
      {
        thread.Start();
        // Anything passed to Do is executed in that ActionThread.
        thread.Do(() =>
        {
          // Create BGW or call TaskScheduler.FromCurrentSynchronizationContext.
        });
        // The thread is gracefully exited at the end of the using block.
      }
    }
