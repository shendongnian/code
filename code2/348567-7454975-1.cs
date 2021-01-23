      var assembly = Assembly.LoadFrom(@"C:\MyAssembly.dll");
      var types = from t in assembly.GetTypes()
                  where t.IsPublic
                  select t;
      foreach(var type in types)
      {
          Console.WriteLine(type.Name);
      }
            
