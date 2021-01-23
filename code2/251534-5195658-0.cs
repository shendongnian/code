    public class MyService
    {
        public void ProcessAll()
        {
          foreach (ICustomInterfaceThatDoesSomething icitds in GetAllImplementers())
            icitds.DoSomething();
        }
        protected virtual IEnumerable<ICustomInterfaceThatDoesSomething> GetAllImplementers()
        {
          // note that the Spring dependency is gone
          // you can also make this method abstract, 
          // or create a more useful default implementation
          return new List<ICustomInterfaceThatDoesSomething>(); 
        }
    }
