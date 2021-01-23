    public bool SomeMethod(out List<Task> tasks) {
       tasks = new List<Task>();
       var task = Task.Factory.StartNew(() => Process.Start(info);
       tasks.Add(task);
    }
