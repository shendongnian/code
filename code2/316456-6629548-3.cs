    // Create Domain
    _RemoteDomain = AppDomain.CreateDomain(_RemoteDomainName,
       AppDomain.CurrentDomain.Evidence, 
       AppDomain.CurrentDomain.BaseDirectory, 
       AppDomain.CurrentDomain.BaseDirectory, 
       true);
    // Load an Assembly Loader in the domain (mine was Builder)
    // This loads the Builder which is in the current domain into the remote domain
    _Builder = (Builder)_RemoteDomain.CreateInstanceAndUnwrap(
        Assembly.GetExecutingAssembly().FullName, "<namespace>.Builder");
    _Builder.Execute(pathToTestDll)
     
    public class Builder : MarshalByRefObject 
    { 
        public void Execute(string pathToTestDll)
        {
            // I used this so the DLL could be deleted while
            // the domain was still using the version that
            // exists at this moment.
            Assembly newAssembly = Assembly.Load(
               System.IO.File.ReadAllBytes(pathToTestDll));
            Type testClass = newAssembly.GetType("<namespace>.TestClass", 
               false, true);
            if (testClass != null)
            {
               // Here is where you use reflection and/or an interface
               // to execute your method(s).
            }
        }
    }
