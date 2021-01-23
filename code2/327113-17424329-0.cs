        Dictionary<string, Assembly> _libs = new Dictionary<string, Assembly>();
        public Form1()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
        }
        // dll handler
        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string keyName = new AssemblyName(args.Name).Name;
            
            // If DLL is loaded then don't load it again just return
            if (_libs.ContainsKey(keyName)) return _libs[keyName];
            using (Stream stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(DllResourceName("itextsharp.dll")))  // <-- To find out the Namespace name go to Your Project >> Properties >> Application >> Default namespace
            {
                byte[] buffer = new BinaryReader(stream).ReadBytes((int)stream.Length);
                Assembly assembly = Assembly.Load(buffer);
                _libs[keyName] = assembly;
                return assembly;
            }
        }
        private string DllResourceName(string ddlName)
        {
            string resourceName = string.Empty;
            foreach (string name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (name.EndsWith(ddlName))
                {
                    resourceName = name;
                    break;
                }
            }
            return resourceName;
        }
