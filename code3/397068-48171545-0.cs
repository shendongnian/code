    <!-- language: lang-cs -->
    
        public static class StaticClass
        {
            // actual constructor
            static StaticClass()
            {
                Initialize();
            }
            
            // explicit "constructor"
            public static void Initialize()
            {
                MyProperty = "Some Value";
            }
    
            public static string MyProperty { get; set; }
    
        }
    
    Then initialize like this if you want:
    
    <!-- language: lang-cs -->
    
        StaticClass.Initialize();
    Or it will be dynamically initialized the first time it's used
