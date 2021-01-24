    public static class Singleton<T>: MonoBehavior where T: MonoBehavior{
      private static T instance;
      
      //Notice the lower and upper case difference here
      public static T Instance{
        get{
          if(instance == null){
            instance = GameObject.FindGameObjectOfType<T>();
          }
          return instance;
        }
      }
    }
