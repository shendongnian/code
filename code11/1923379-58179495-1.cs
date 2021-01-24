    public Package GetRootPackage()
    {
    	try
    	{
    		var repo = new EA.Repository();
    
    		repo.OpenFile(_connectionString);
    
    		var pkg = (EA.Package)repo.Models.GetByName(this.RootPackageName);
    
    		if (pkg is null)
    			throw new ApplicationException($"Package \"{this.RootPackageName}\" not found.");
    
    		return pkg;
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex);
    		throw;
    	}
		finally
		{
			Console.WriteLine("Closing repository...");
			repo.CloseFile();
		}
    }
