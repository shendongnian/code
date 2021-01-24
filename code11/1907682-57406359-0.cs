      public class GenericDependencyInjection
        {
            private static readonly UnityContainer UnityContainer = new UnityContainer();
    
            public GenericDependencyInjection()
            {
                try
                {
                    UnityContainer.RegisterType<IOperations,Operations>(new ContainerControlledLifetimeManager());
                }
                catch (Exception ex)
                {
                    throw ;
                }
            }
    		
    		  public T Retrieve<T>()
            {
                return UnityContainer.Resolve<T>();
            }
    		
    		}
