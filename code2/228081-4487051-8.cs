    // functor class
    class Runner {
        string ArgString {get;set;}
        object ArgContext {get;set;}
        // CTOR: encapsulate args and a context to run them in
        public Runner(string str, object context) {
            ArgString = str;
            ArgContext = context;
        }
        // This is the item processor logic. 
        public void Process() {
            // process ArgString normally in ArgContext
        }
    }
