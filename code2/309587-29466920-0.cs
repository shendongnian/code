    public MainWindow()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                Assembly thisAssembly = Assembly.GetEntryAssembly();
                String resourceName = string.Format("{0}.{1}.dll",
                    thisAssembly.EntryPoint.DeclaringType.Namespace,
                    new AssemblyName(args.Name).Name);
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
        }
