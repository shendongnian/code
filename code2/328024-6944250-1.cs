    public class Singleton {
        public static void Initialize() {
            //this accesses the static field of the inner class which triggers the private Singleton() ctor.  
            Instance._Initialize();
        }
        private void _Initialize()
        { //do nothing
        }
        
        [the rest as before]
    }
