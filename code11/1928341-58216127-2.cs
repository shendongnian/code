    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //automatically create the database
            context.Database.EnsureCreated();
            
            //The following is the data you want
            ....
        }
    }
