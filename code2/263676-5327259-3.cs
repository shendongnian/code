    ThreadPool.QueueUserWorkItem(state => {
        Dispatcher.BeginInvoke((Action)delegate() { btnRefresh.IsEnabled = false; });
        foreach (var user in service.GetAllUsers())
            vm.Users.Add(user);
        Dispatcher.BeginInvoke((Action)delegate() { btnRefresh.IsEnabled = true; });
     
    });
