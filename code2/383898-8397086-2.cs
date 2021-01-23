    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel.Unity;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    
    namespace RowMapperConsole 
    {
        public class Region {}
     
        public class RowMapperCache
        { 
            private Dictionary<Type, object> cache = new Dictionary<Type, object>();
            private object locker = new object();
    
            public IRowMapper<T> GetCachedMapper<T>() where T : new()
            {
                Type type = typeof(T);
               
    	    lock (locker)
                {
                    if (!Contains(type))
                    {
                        cache[type] = MapBuilder<T>.BuildAllProperties();
                    }
                }
    
                return cache[type] as IRowMapper<T>;
            }
    
            private bool Contains<T>(T type) where T : Type
            {
                return cache.ContainsKey(type);
            } 
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                ApplicationInitialize();
    
                // ...
    
                IEnumerable<Region> regions = GetRegions();
            }
    
            public static void ApplicationInitialize()
            {
                ConfigureContainer(container =>
                {
                    // Register as Singleton
                    container.RegisterType<RowMapperCache>(new ContainerControlledLifetimeManager());
                });
            }
    
            public static void ConfigureContainer(Action<IUnityContainer> action)
            {
                IUnityContainer container = new UnityContainer();
     
                if (action != null)
                    action(container);
    
                IContainerConfigurator configurator = new UnityContainerConfigurator(container);
                EnterpriseLibraryContainer.ConfigureContainer(configurator, ConfigurationSourceFactory.Create());
                IServiceLocator locator = new UnityServiceLocator(container);
                EnterpriseLibraryContainer.Current = locator;
            }
    
            public static IEnumerable<Region> GetRegions()
            {
                IRowMapper<Region> regionMapper = EnterpriseLibraryContainer.Current.GetInstance<RowMapperCache>()
                                                      .GetCachedMapper<Region>();
                var db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
     
                return db.ExecuteSqlStringAccessor<Region>("SELECT * FROM Region", regionMapper).ToList();
            }
        }
    }
