    public static async void Await(this Task task, Action action = null)
    {
       await task;
       if (action != null)
          action();
    }
    runningTask.Await();
