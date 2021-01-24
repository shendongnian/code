            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SomeObject, SomeObject>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });
            IMapper mapper = new Mapper(mapperConfig);
            var test = new SomeObject(1) { Name = "Fred" }; // object we will clone.
            var test2 = new SomeObject(); // example of an existing "new" object to copy values into...
            mapper.Map(test, test2); // Copy values from first into 2nd..
            var test3 = mapper.Map<SomeObject>(test); // Example of letting automapper create a new clone.
