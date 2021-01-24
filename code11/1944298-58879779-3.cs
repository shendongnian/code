    public void DoSomeProcess(string data, Action<string> callback)
    {
        // Some process
        callback("data processed");
    }
