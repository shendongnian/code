        internal static class SpringApplicationContext
        {
            private static IApplicationContext applicationContext = null;
    
            static SpringApplicationContext()
            {
                applicationContext = ContextRegistry.GetContext();
            }
    
            public static IApplicationContext ApplicationContext
            {
                get { return applicationContext; }
            }
        }
    
