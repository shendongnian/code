    public interface MyInterface
    {
        void Init(string s);
        string S { get; set; }
    }
    T SomeMethod<T>(string s) : where T : MyInterface, new()
    {
        var t = new T();
        t.Init(s);
        var t = new T
        { 
            S = s
        };
        
        return t;
    }
