        private void Form1_Load(object sender, EventArgs e)
        {
            //The AssemblyResolve event is called when the common language runtime tries to bind to the assembly and fails.
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(currentDomain_AssemblyResolve);
        }
	
        //This handler is called only when the common language runtime tries to bind to the assembly and fails.
        Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllPath = Path.Combine(YourPath, new AssemblyName(args.Name).Name) + ".dll";
            return (File.Exists(dllPath))
                ? Assembly.Load(dllPath)
                : null;
        }
