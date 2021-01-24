        private static ISessionFactory CreateSessionFactory() {
            var configuration = new Configuration();
            //here we add all hbm.xml mapping into configuration
            NHibernateHelpers.AddMapping(configuration);
            return configuration.BuildSessionFactory();
        }
//the trick is here, here we load all mappings
internal class NHibernateHelpers
    {        
        public static void AddMapping(Configuration cfg)
        {
            // you can use some params to replace it in the mapping file
            // for example if you need same tables with different data in it
            // Employee01, Enoloyee02 and in mapping file you could write something like  Employee<code>
            var @params = new Dictionary<string, object>
            {
               { "code", "01" },                
            };
            var assemblies = new Queue<Assembly>(AppDomain.CurrentDomain.GetAssemblies());
            var assemblyNames = assemblies.Select(ass => ass.FullName).ToList();
            
            while (assemblies.Count > 0)
            {
                Assembly ass = assemblies.Dequeue();
                //for each assebmly look for
                //ReferencedAssemblies and load them
                foreach (var refAss in ass.GetReferencedAssemblies())
                {
                    if (!assemblyNames.Contains(refAss.FullName))
                    {
                        // condition to load only your assemblies here we check for 
                        //unsigned one
                        if (refAss.GetPublicKeyToken().Length == 0)
                        {
                            assemblies.Enqueue(Assembly.Load(refAss.FullName));
                            assemblyNames.Add(refAss.FullName);
                        }
                    }
                }
            }
            List<Assembly> assembles = AppDomain.CurrentDomain.GetAssemblies().ToList();
           
            foreach (var assembly in assembles)
            {
                // if assembly is dynamic there is an Exception
                try
                {
                    var tmp = assembly.Location;
                }
                catch
                {
                    continue;
                }
                
                foreach (var resName in assembly.GetManifestResourceNames())
                {
                    if (resName.EndsWith(".hbm.xml"))
                    {
                        var str = new StreamReader(assembly.GetManifestResourceStream(resName)).ReadToEnd();
                        //here u can replace parameters you need I've left comment above
                        //str = str.Replace(...)
                        cfg.AddXmlString(str);
                    }
                }
            }
        }
    }
}
Hope it will help.
