    interface INameable
    {
       string Name { get; }
    }
    class MyClass
    {
      ISessionFactory m_SessionFactory;
      public T FindName<T>(string name) where T : class, INameable
      {
         T obj;
         using (ISession session = m_SessionFactory.OpenSession())
         {
            obj = session.QueryOver<T>()
                .Where(x => x.Name == name).SingleOrDefault();
         }
         return obj;
      }
