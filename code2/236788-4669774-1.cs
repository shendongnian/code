       public static IRepository<T> GetRepository<T>()
       { 
           return container.Resolve<T>()
       }
       // to call it
       var repository = ObjectFactory.GetRepository<IClinicRepository>();
