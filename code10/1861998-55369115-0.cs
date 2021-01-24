    public static MyClass Instance
    {
        get
        {
			var instanceSafeRef = _instance;
            if(instanceSafeRef == null)
            {
                lock(_padlock)
                {
                    if(_instance == null)
                    {
                        _instance = new MyClass();
                    }
					instanceSafeRef = _instance;
                }
            }
            return instanceSafeRef;
        }
        set => _instance = value;
    }
