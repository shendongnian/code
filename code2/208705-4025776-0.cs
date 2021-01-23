    class ServiceFactory 
    {
         Dictionary<Type, NewService> serviceCreators;
         ServiceFactory() 
         {
             serviceCreators = new Dictionary<Type, NewService>();
             serviceCreators.Add(typeof(Task1), delegate { return new SomeService(); });
             serviceCreators.Add(typeof(Task2), delegate { return new SomeOtherService(); });
         }
    
         public IService CreateService(IServiceTask messageObj) 
         {
             if(serviceCreators.Contains(messageObj.GetType()) 
             {
                  return serviceCreators[messageObj.GetType()];
             }
             return new DefaultService();
         }
    }
    
    delegate IService NewService();
