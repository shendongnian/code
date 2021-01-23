    private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            RegistrationServices regsrv = new RegistrationServices();
            if (!regsrv.RegisterAssembly(GetType().Assembly, AssemblyRegistrationFlags.SetCodeBase))
            {
            	throw new Exception("Failed to register for COM Interop.");
            }
        }
    
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            RegistrationServices regsrv = new RegistrationServices();
            if (!regsrv.UnregisterAssembly(GetType().Assembly))
            {
	            throw new Exception("Failed to unregister for COM Interop.");
            }
        }
