    namespace Factory
    {
      public static class Invoker<T> where T: IBusinessRules
      {
        public static T FetchInstance(string clientCode)
        {
            var clientAssembly = Assembly.LoadFrom(clientCode + ".dll");
    
            return (T)clientAssembly.CreateInstance(clientCode+".BusinessRules");
        }
      }
    }
