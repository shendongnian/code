    private void RaiseMyEvent(MyEventArgs e)
    {
        var handler = this.TheEvent;
        if (handler != null)
        {
            var tasks = new List<Task>();
            foreach(var yourEvent in handler.GetInvocationList().Cast<EventHandler<MyEventArgs>())
                tasks.Add(Task.Factory.StartNew( () => yourEvent(this, e)));
            // Optionally wait here...  Removing the following makes this asynchronous
            Task.WaitAll(tasks.ToArray());
        }
    }
