    List<string> StringList; //Populated in previous code
    Dictionary<string,Type> assemblyTypes = RandomAssembly.GetTypes()
        .ToDictionary(t => t.Name, t => t);
    foreach (String name in StringList)
    {                               
        if (assemblyTypes.ContainsKey(name))
        {                                       
          //Do stuff.
        }
      }
    }
