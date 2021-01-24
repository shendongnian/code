    //Create a new app domain
    AppDomain m_appDomain = AppDomain.CreateDomain("AD #2", null, 
    AppDomain.CurrentDomain.SetupInformation);
    //Get the assembly that you are trying to load
    Assembly assembly = Assembly.LoadFile("somepath");
    //Load the desired assembly 
    m_appDomain.Load(assembly);
    //Create an instance of a class in the new AppDomain it must be a child of MarshalbyRefType
    DropboxController dropboxController = (DropboxController)
    m_appDomain.CreateInstanceAndUnwrap(
    assembly.FullName,
    typeof(DropboxController).FullName);
    
     dropboxController.PrintDomain(); //Will print "AD #2" and it will use the desired assembly 
