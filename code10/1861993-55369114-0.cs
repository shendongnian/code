    public static MyClass Instance
    {
        get
        {
             lock(_padlock)
             {
                 if(_instance == null)
                     _instance = new MyClass();
                 return _instance;
             }
        }
        set 
        {
             lock(_padlock)
             {
                 _instance = value;
             }
        } 
    }
