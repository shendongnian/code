     Assembly assembly = Assembly.GetCallingAssembly();
     foreach (var part in Container.Catalog.Parts)
     {
         if(assembly.GetType(part.ToString()).GetInterface(yourInterfaceStringName) != null)
         {
             DOSOMETHING
         }
     }
