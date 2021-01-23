    class Singleton
    {
         private static Singleton _mainInstance = new Singleton();
         private Singleton() { }
         public void Clone() {..}
    
         public static Singleton MainInstance
         {
             return _mainInstance;
         }
    }
