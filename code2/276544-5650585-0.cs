    // add usings:
              // using System.IO;
              // using System.Reflection;
              public Dictionary<string,string> FindInterfacesInDirectory(string directory)
              {
                 //is directory real?
                 if(!Directory.Exists(directory))
                 {
                    //exit if not...
                    throw new DirectoryNotFoundException(directory);
                 }
        
                 // set up collection to hold file name and interface name
                 Dictionary<string, string> returnValue = new Dictionary<string, string>();
        
                 // drill into each file in the directory and extract the interfaces
                 DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                 foreach (FileInfo fileInfo in directoryInfo.GetFiles() )
                 {
                    foreach (Type type in Assembly.LoadFile(fileInfo.FullName).GetTypes())
                    {
                       if (type.IsInterface)
                       {
                          returnValue.Add(fileInfo.Name, type.Name);
                       }
                    }
                 }
        
                 return returnValue;
        
              }
