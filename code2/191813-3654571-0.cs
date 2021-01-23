     AppDomain.CurrentDomain
              .GetAssemblies()
              .SelectMany(assembly => nameSpaceSuffixes.Select(suffix =>
                                      new { Assembly = assembly, Suffix = suffix }))   
              .Where(anon => anon.Assembly.GetName().Name.EndsWith(anon.Suffix))       
              .ToList()
              .ForEach(anon => Register(container, anon.Assembly, anon.Suffix);
        
