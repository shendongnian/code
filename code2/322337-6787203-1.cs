    void addServers(ObservableCollection<ServerObjects> ACollection)
    {
        //For Common szenarios dont use new Thread() use instead ThreadPool.QueueUserWorkItem(..) or  the TaskFactory
        Task.Factory.StartNew(()=> this.LoadServer());
    }
    
    void MyThreadMethod(Object obj)
    {
        ServerObjects so = getServers();
        // The invoke is important, because only the UI Thread should update controls or datasources which are bound to a Control
        UIDispatcher.Invoke(new Action(()=> (obj as ObservableCollection).add(so));
    }
