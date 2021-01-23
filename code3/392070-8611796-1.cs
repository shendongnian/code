    class MyClass
    {
        private Exposition exposition;
        
        // Option 1: Use parametrized constructor
        // Pass the instance reference of the other class while 
        // constructing the object
        public MyClass(Exposition exposition)
        {
            this.exposition = exposition;
        }
    
        // Option 2: Use an initialize method
        public void Initialize(Exposition exposition)
        {
            this.exposition = exposition;
        }
    
        // Remove static to access instance members
        public void OnTimedEvent(object scource, ElapsedEventArgs e) 
        {   
            // Better to use an enumeration/switch instead of magic constants
            switch(exposition.Narration)
            { 
                 case HotAndMuggy:
                     Console.WriteLine("The bar is hot and muggy");;
                     break;
                 ...
            }
        }     
        // Option 3: Use static properties of the Exposition class
        // Note this approach should be used only if your application demands 
        // only one instance of the class to be created        
        public static void OnTimedEvent_Static(object scource, ElapsedEventArgs e) 
        {   
            // Better to use an enumeration/switch instead of magic constants
            switch(Exposition.Narration)
            { 
                 case HotAndMuggy:
                     Console.WriteLine("The bar is hot and muggy");;
                     break;
                 ...
            }
        }        
    }
