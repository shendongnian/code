    public MyCollection(TaskScheduler scheduler) {
      this.taskFactory = new TaskFactory(scheduler);
    }
    
    public void Add(object x) {
      taskFactory.StartNew(() => {
        list.Add(x);
      });
    }
