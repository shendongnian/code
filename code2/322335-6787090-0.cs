    void addServers(ObservableCollection<ServerObjects> ACollection)
    {
        Thread T = new Thread(new ParameterizedThreadStart(MyThreadMethod));
        T.Start(ACollection);
    }
    void MyThreadMethod(Object obj)
    {
        ServerObjects so = getServers();
        (obj as ObservableCollection).add(so);
    }
