    public bool SomeMethod(out List<Task> tasks) {
      var task = Task.Factory.StartNew(() => Process.Start(info);
      tasks = new List<Task>() { task };
      ...
    }
