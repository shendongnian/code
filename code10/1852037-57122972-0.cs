      public System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("Newtonsoft.Json"))
            {
                string path = @"D:\Projects\FortiAnalyzer\FortiAnalyzer\FortiAnalyzer\bin\portable-net45+win8+wp8+wpa81\Newtonsoft.Json.dll";
                return System.Reflection.Assembly.LoadFile(@path);
            }
            return null;
        }
