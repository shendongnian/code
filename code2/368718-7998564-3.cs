            var config = new WebApiConfiguration();
            config.ModelValidationFor<T>(); //Instead of passing a T object pass the object you want to validate
            routes.SetDefaultHttpConfiguration(config);
            
            routes.MapServiceRoute<PhysicalTestResource>("EHR");
