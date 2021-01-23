    public sealed class Singleton
    {
       ..........................
    
            private static object locker = new object();
            private static bool initialized = false;
    
            public static void Initialize() {
               if (!initialized){ 
                 lock(locker) {
                    if (!initialized){ 
                      //write initialization logic here
                      initialized = true;
                     }
                  }
                }
            }
    
    .......................
    
    }
