    sealed class PreMergeToMergedDeserializationBinder : SerializationBinder
    {
       private readonly bool _searchInDlls;
    
       public PreMergeToMergedDeserializationBinder(bool searchInDlls)
       {
          _searchInDlls = searchInDlls;
       }
    
       public override Type BindToType(string assemblyName, string typeName)
       {
          List<AssemblyName> assemblyNames = new List<AssemblyName>();
          assemblyNames.Add(Assembly.GetExecutingAssembly().GetName()); // EXE
    
          if (_searchInDlls)
          {
             assemblyNames.AddRange(Assembly.GetExecutingAssembly().GetReferencedAssemblies()); // DLLs
          }
             
          foreach (AssemblyName an in assemblyNames)
          {
             var typeToDeserialize = GetTypeToDeserialize(typeName, an);
             if (typeToDeserialize != null)
             {
                return typeToDeserialize; // found
             }
          }
    
          return null; // not found
       }
    
       private static Type GetTypeToDeserialize(string typeName, AssemblyName an)
       {
          string fullTypeName = string.Format("{0}, {1}", typeName, an.FullName);
          var typeToDeserialize = Type.GetType(fullTypeName);
          return typeToDeserialize;
       }
    }
