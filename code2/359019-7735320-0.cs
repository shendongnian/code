    var task = Task.Factory.StartNew(() =>
    {
      Thread.Sleep(5000);
      throw new Exception();
    });
    
    bool taskCompleted = task.Wait(4000); // No exception
    bool taskCompleted = task.Wait(6000); // Exception
