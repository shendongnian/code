    namespace Test
    {
        class Program
        {
            /// ------------------------------------------------------------------------------            
            /// IMPORTANT: 
            /// you MUST exclude Interfaces.dll from being copied in Plugins directory,
            /// otherwise plugins will use that and they're not recognized as using
            /// the same IPlugin interface used in main code.
            /// ------------------------------------------------------------------------------            
            static void Main(string[] args)
            {
                List<Interfaces.IPlugin01> list1 = new List<Interfaces.IPlugin01>();
                List<Interfaces.IPlugin01> list2 = new List<Interfaces.IPlugin01>();
    
                List<Interfaces.IPlugin01> listtot = GetDirectoryPlugins<Interfaces.IPlugin01>(@".\Plugins\");
    
                Console.WriteLine("--- 001 ---");
                foreach(Interfaces.IPlugin01 plugin in list1)
                    plugin.Calc1();
    
                Console.WriteLine("--- 002 ---");
                foreach (Interfaces.IPlugin01 plugin in list2)
                    plugin.Calc1();
    
                Console.WriteLine("--- TOT ---");
                foreach (Interfaces.IPlugin01 plugin in listtot)
                    plugin.Calc1();
                Console.ReadLine();
            }
    
            public static List<T> GetFilePlugins<T>(string filename)
            {
                List<T> ret = new List<T>();
                if (File.Exists(filename))
                {
                    Assembly ass = Assembly.LoadFrom(filename);
                    foreach (Type type in ass.GetTypes())
                    {
                        if (!type.IsClass || type.IsNotPublic) continue;
                        if (typeof(T).IsAssignableFrom(type))
                        {
                            T plugin = (T)Activator.CreateInstance(type);
                            ret.Add(plugin);
                        }
                    }
                }
                return ret;
            }
            public static List<T> GetDirectoryPlugins<T>(string dirname)
            {
                /// To avoid that plugins use Interfaces.dll in their directory,
                /// I delete the file before searching for plugins.
                /// Not elegant perhaps, but functional.
                string idll = Path.Combine(dirname, "Interfaces.dll");
                if (File.Exists(idll)) File.Delete(idll);
    
                List<T> ret = new List<T>();
                string[] dlls = Directory.GetFiles(dirname, "*.dll");
                foreach (string dll in dlls)
                {
                    List<T> dll_plugins = GetFilePlugins<T>(Path.GetFullPath(dll));
                    ret.AddRange(dll_plugins);
                }
                return ret;
            }
        }
