     namespace Factory
     {
        public static class Invoker<T> where T : Foundation.IBusinessRules
        {
            public static T FetchInstance(string clientCode)
            {
               Type objType = Type.GetType(clientCode + ".BusinessRules," + clientCode);
               return (T)Activator.CreateInstance(objType);
    
        }
    }
