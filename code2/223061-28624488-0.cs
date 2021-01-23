    private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
            {
                Assembly assembly = null;
                string keyName = new AssemblyName(args.Name).Name;
                if (keyName.Contains(".resources"))
                {
                    return null;  // This line is what fixed the problem
                }
                if (_libs.ContainsKey(keyName))
                {
                    assembly = _libs[keyName]; // If DLL is loaded then don't load it again just return
                    return assembly;
                }
                
                string dllName = DllResourceName(keyName);
                //string[] names = Assembly.GetExecutingAssembly().GetManifestResourceNames();   // Uncomment this line to debug the possible values for dllName
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(dllName))
                {
                    if (stream == null)
                    {
                        Debug.Print("Error! Unable to find '" + dllName + "'");
                        // Uncomment the next lines to show message the moment an assembly is not found. (This will also stop for .Net assemblies
                        //MessageBox.Show("Error! Unable to find '" + dllName + "'! Application will terminate.");
                        //Environment.Exit(0);
                        return null;
                    }
    
                    byte[] buffer = new BinaryReader(stream).ReadBytes((int) stream.Length);
                    assembly = Assembly.Load(buffer);
    
                    _libs[keyName] = assembly;
                    return assembly;
                }
            }
    
            private static string DllResourceName(string ddlName)
            {
                if (ddlName.Contains(".dll") == false) ddlName += ".dll";
    
                foreach (string name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                {
                    if (name.EndsWith(ddlName)) return name;
                }
                return ddlName;
            }
