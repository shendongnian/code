    public void DoMagic()
    {
		// NOTE: After this, you can use your typeconverter.
    	AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    }
    
    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
    	AppDomain domain = (AppDomain)sender;
    	foreach (Assembly asm in domain.GetAssemblies())
    	{
    		if (asm.FullName == args.Name)
    		{
    			return asm;
    		}
    	}
    	return null;
    }
