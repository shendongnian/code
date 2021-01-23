    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace ibKastl.Helper
    {
       public static class BinaryFormatterHelper
       {
          public static T Read<T>(string filename, Assembly currentAssembly)
          {
             T retunValue;
             FileStream fileStream = new FileStream(filename, FileMode.Open);
    
             try
             {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Binder = new SearchAssembliesBinder(currentAssembly,true);            
                retunValue = (T)binaryFormatter.Deserialize(fileStream);
             }
             finally
             {
                fileStream.Close();
             }
    
             return retunValue;
          }
    
          public static void Write<T>(T obj, string filename)
          {
             FileStream fileStream = new FileStream(filename, FileMode.Create);
             BinaryFormatter formatter = new BinaryFormatter();
             try
             {
                formatter.Serialize(fileStream, obj);
             }
             finally
             {
                fileStream.Close();
             }
          }
       }
    
       sealed class SearchAssembliesBinder : SerializationBinder
       {
          private readonly bool _searchInDlls;
          private readonly Assembly _currentAssembly;
    
          public SearchAssembliesBinder(Assembly currentAssembly, bool searchInDlls)
          {
             _currentAssembly = currentAssembly;
             _searchInDlls = searchInDlls;
          }
    
          public override Type BindToType(string assemblyName, string typeName)
          {
             List<AssemblyName> assemblyNames = new List<AssemblyName>();
             assemblyNames.Add(_currentAssembly.GetName()); // EXE
    
             if (_searchInDlls)
             {
                assemblyNames.AddRange(_currentAssembly.GetReferencedAssemblies()); // DLLs
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
    
    }
