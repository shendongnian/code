    class Program
    {
        static string _PluginDirectory;
        static string PluginDirectory
        {
            get
            {
                if (_PluginDirectory == null)
                {
                    _PluginDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"Plugins");
                }
                return _PluginDirectory;
            }
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            AssemblyName assemblyName = new AssemblyName(args.Name);
            return Assembly.LoadFile(System.IO.Path.Combine(PluginDirectory, assemblyName.Name + ".dll"));
        }
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            var asm = Assembly.LoadFile(System.IO.Path.Combine(PluginDirectory, @"Plugin.dll"));
            var transmogrifier = asm.CreateInstance("Plugin.ConcreteTransmogrifier") as Common.Transmogrifier;
            if (transmogrifier != null)
            {
                Console.WriteLine(transmogrifier.Transmogrify("Wowzers!"));
            }
        }
    }
