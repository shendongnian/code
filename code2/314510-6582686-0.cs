    class User
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    }
    
    void GetName(IAsyncResult result)
    {
        var user = (User)result.AsyncState
        // ...
    }
    
    AsyncCallback callBack = new AsyncCallback(GetName);
