    Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        //This handler is called only when the common language runtime tries to bind to the assembly and fails.
        //Retrieve the list of referenced assemblies in an array of AssemblyName.
        Assembly MyAssembly, objExecutingAssemblies;
        string strTempAssmbPath = "";
        objExecutingAssemblies = Assembly.GetExecutingAssembly();
        AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();
        //Loop through the array of referenced assembly names.
        foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
        {
            //Check for the assembly names that have raised the "AssemblyResolve" event.
            if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
            {
                //Build the path of the assembly from where it has to be loaded.
                //The following line is probably the only line of code in this method you may need to modify:
                strTempAssmbPath = "C:\\Program Files\\PATH TO YOUR FOLDER" + "\\Newtonsoft.Json\\9.0.1";
                if (!strTempAssmbPath.EndsWith("\\")) strTempAssmbPath += "\\";
                //strTempAssmbPath += args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
                strTempAssmbPath += strAssmbName.Name + ".dll";
                break;
            }
        }
        //Load the assembly from the specified path.
        MyAssembly = Assembly.LoadFrom(strTempAssmbPath);
        //Return the loaded assembly.
        return MyAssembly;
    }
