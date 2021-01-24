    public static GameController Instance
    {
        get
        {
            if(!_instance) _instance = FindObjectOfType<GameController>();
           
            return _instance;
        }  
        private set
        {
            _instance = value;
        }
    }
