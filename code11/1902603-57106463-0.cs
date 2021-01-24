    public static GameController Instance
    {
        get
        {
            if(!_instance)
            {
                var obj = GameObject.FindWithTag("GameController");
                if (obj)
                {
                      _instance = obj.GetComponent<GameController>();
                }
            }
            return _instance;
        }  
        private set
        {
            _instance = value;
        }
    }
