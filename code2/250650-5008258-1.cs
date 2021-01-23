        string dllPath = "C:\\ProjectsTest\\TestSolution\\ActiveXUser\\bin\\Debug\\TestControl.dll";
    if (!File.Exists(dllPath)) {
    	return;
    }
    
    string versionInformation = null;
    versionInformation = Environment.Version.Major.ToString() + Environment.Version.Minor;
    
    Assembly loadedAssembly = Assembly.LoadFile(dllPath);
    
    Type[] mytypes = loadedAssembly.GetTypes();
    
    Type t = mytypes[1];
    Object obj = Activator.CreateInstance(t);
    
    versionInformation = Environment.Version.Major.ToString() + Environment.Version.Minor;
    this.Panel1.Controls.Add(obj);
