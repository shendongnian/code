    static class Globals
    {
        // global int 
        public static int counter;
    
        // global function
        public static string HelloWorld()
        {
            return "Hello World";
        }
    }
    Globals.counter = 10;
    int localcounter = Globals.counter;
    string somestring = Globals.HelloWorld();
    Globals.counter2 = 30;
    int localcounter2 = Globals.counter2;
