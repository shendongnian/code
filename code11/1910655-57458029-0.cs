    private static Level instance;
    
    public static Level Instance {
         get {
              if (instance == null){
                   instance = FindObjectOfType<Level>();
              }
              return instance
         }
    }
