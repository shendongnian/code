    public sealed class Client
      {
        // A private constructor to restrict the object creation from outside
        private Client()
         {
          ...
         }
        // A private static instance of the same class
        private static Singleton instance = null;
        public static Client GetInstance()
          {
           // create the instance only if the instance is null
           if (instance == null)
             {
               instance = new Client();
             }
           // Otherwise return the already existing instance
          return instance;
          }
      }
