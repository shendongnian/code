    public void HomeAsync(Axis axis, Action<bool> callback)
    {
        Task.Factory
            .StartNew(() => Home(axis))
            .ContinueWith(task => callback(task.Result));
    }
