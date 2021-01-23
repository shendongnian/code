    public static bool IsComPlusApplicationRunning(string appName)
    {
        COMAdmin.COMAdminCatalog catalog = new COMAdmin.COMAdminCatalogClass();
    
        COMAdmin.ICatalogCollection appCollection = (COMAdmin.ICatalogCollection)catalog.GetCollection("Applications");
        appCollection.Populate();
    
        Dictionary<string, string> apps = new Dictionary<string, string>();
        COMAdmin.ICatalogObject catalogObject = null;
    
        // Get the names of the applications with their ID and store for later
        for (int i = 0; i < appCollection.Count; i++)
        {
            catalogObject = (COMAdmin.ICatalogObject)appCollection.get_Item(i);
            apps.Add(catalogObject.get_Value("ID").ToString(), catalogObject.Name.ToString());
        }
    
        appCollection = (COMAdmin.ICatalogCollection)catalog.GetCollection("ApplicationInstances");
        appCollection.Populate();
    
        for (int i = 0; i < appCollection.Count; i++)
        {
            catalogObject = (COMAdmin.ICatalogObject)appCollection.get_Item(i);
    
            if (string.Compare(appName, apps[catalogObject.get_Value("Application").ToString()], StringComparison.OrdinalIgnoreCase) == 0)
            {
                Console.WriteLine(appName + " is running with PID: " + catalogObject.get_Value("ProcessID").ToString());
                return true;
            }
        }
    
        return false;
    }
