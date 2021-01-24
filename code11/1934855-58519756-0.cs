public void Foo()
{
	AppDomain currentDomain = AppDomain.CurrentDomain;
	currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
    // Load dll which was exported from Matlab into application
	string path = @"..\..\..\..\MatlabDlls\Matlab-Integration";
    string dllName = "MyExportedMatlabDLL.dll";
	List<string> dllPaths = Directory.GetFiles(path).Where(file => file.EndsWith(dllName)).ToList();
	FileInfo info = new FileInfo(dllPaths[0]);
	Assembly matlabAssembly = Assembly.LoadFrom(info.FullName);
    // Get types from exported dll
	List<Type> exportedMatlabTypes = new List<Type>();
	exportedMatlabTypes = matlabAssembly.GetTypes().ToList();
	List<MethodInfo> methods = new List<MethodInfo>();
	methods.AddRange(exportedMatlabTypes[0].GetMethods());
    // Create instance of exported Matlabtype 
	dynamic dynamicObject = Activator.CreateInstance(exportedMatlabTypes[0]);
	// Select MWArray from loaded Assemblies
    // Important: MWArray could only be loaded into the application with
    // the ResolveEventHandler further below
	Assembly mwArrayAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(name => name.FullName.Contains("MWArray")).ToList()[0];
	
    // Get all available types of MWArray
    List<Type> MWArrayTypes = mwArrayAssembly.GetTypes().ToList();							
	
    // Create some MWArrays
    // MWNummericArray
	dynamic array1 = Activator.CreateInstance(MWArrayTypes[9], new object[] { new byte[640 * 480]});
	//MWNummericArray
    dynamic array2 = Activator.CreateInstance(MWArrayTypes[9], new object[] { 100 });
	//MWLogicalArray
	dynamic array3 = Activator.CreateInstance(MWArrayTypes[5], new object[] { true });
    
    // Parameters for Matlab function 
	object[] params= new object[] { array1, array2, array3};
	
    MethodInfo matlabFuncion = methods[5];		
	var result = matlabFuncion.Invoke(dynamicObject, params);
}
// The ResolveEventHandler ensures the proper loading of dependent assemblies
// I wrote a crawler that would search inside the Matlab runtime for dependent 
// assemblies. It is enough to just load "MWArray" from a static path... 
private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
{
	Assembly dependentAssembly = null;
	string assemblyName = args.Name.Split(',')[0];
	string assemblypath = _crawler.getFullName(_runtimepath, assemblyName);
	if (assemblypath != string.Empty)
		dependentAssembly = Assembly.LoadFile(assemblypath);
	return dependentAssembly;
}
