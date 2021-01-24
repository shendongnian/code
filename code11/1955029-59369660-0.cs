     private IProcessor GetProcessor<Tinterface>(string name) where Tinterface : IProcessor
     {
          var type = typeof(Tinterface).Assembly.GetTypes()
                                       .First(x => x.FullName.Contains("name"));
          return (Tinterface)Activator.CreateInstance(type);
     }
