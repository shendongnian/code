     private static [YourScriptName] _instance = null;
     public static [YourScriptName] Instance
     {
         get { return _instance; }
     }
     void Awake()
     {
         if (_instance != null && _instance != this)
         {
             Destroy(gameObject);
             return;
         }
         
         _instance = this;
         
         DontDestroyOnLoad(gameObject);
     }
