    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    namespace Your.Namespace
    {
        public class SafeDirectoryCatalog : AggregateCatalog
        {
            public SafeDirectoryCatalog(string folderLocation)
            {
                var di = new DirectoryInfo(folderLocation);
    
                if (!di.Exists) throw new Exception("Folder not exists: " + di.FullName);
    
                var dlls = di.GetFileSystemInfos("*.dll");
    
                foreach (var fi in dlls)
                {
                    try
                    {
                        var ac = new AssemblyCatalog(Assembly.LoadFile(fi.FullName));
                        var parts = ac.Parts.ToArray(); // throws ReflectionTypeLoadException 
                        this.Catalogs.Add(ac);
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        //Swallow this exception
                    }
                }
            }
        }
    }
