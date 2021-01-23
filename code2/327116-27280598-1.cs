    // To embed a dll in a compiled exe:
    // 1 - Change the properties of the dll in References so that Copy Local=false
    // 2 - Add the dll file to the project as an additional file not just a reference
    // 3 - Change the properties of the file so that Build Action=Embedded Resource
    // 4 - Paste this code before Application.Run in the main exe
    AppDomain.CurrentDomain.AssemblyResolve += (Object sender, ResolveEventArgs args) =>
        {
            String thisExe = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            System.Reflection.AssemblyName embeddedAssembly = new System.Reflection.AssemblyName(args.Name);
            String resourceName = thisExe + "." + embeddedAssembly.Name + ".dll";
    
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return System.Reflection.Assembly.Load(assemblyData);
            }
        };
