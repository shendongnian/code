    public class iocServiceLocator
        {
            private static readonly IUnityContainer _container;
    
            static iocServiceLocator()
            {
               _container = new UnityContainer();
            }
    
            public static void Initialize()
            {
                InitializeBootStrap();
            }
    
            private static void InitializeBootStrap()
            {
                //Register types here                        
            }
    
            public static T Get<T>()
            {
                return _container.Resolve<T>();
            }
    
            public static T Get<T>(string key)
            {
                return _container.Resolve<T>(key);
            }
    
    
        }
