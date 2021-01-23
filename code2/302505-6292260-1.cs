    public static class EntityFrameworkSession
    {
        [ThreadStatic] private static ObjectContext _current;
        public static AssignToSessionFactory()
        {
             SessionFactory.Created += OnCreateObjectContext;
             SessionFactory.Disposed += OnDisposeContext;
        }
    
        public static void OnDisposeContext(object source, SessionEventArgs e)
        {
             if (e.Saved)
               _myContext.SaveChanges();
        }
    }
