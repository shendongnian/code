    public IGPTool GetTool(string _sToolName, string _sToolboxName)
    {
    	IWorkspaceFactory pGPTFact;
    	IToolboxWorkspace pToolboxWorkspace;
    	IGPToolbox pGPToolbox;
    	IGPTool pGPTool;
    
    	pGPTFact = new ToolboxWorkspaceFactoryClass();
    
    	pToolboxWorkspace =  pGPTFact.OpenFromFile(
            ArcGISInstallFolder + @"\ArcToolbox\Toolboxes", 0) as IToolboxWorkspace;
    	pGPToolbox = pToolboxWorkspace.OpenToolbox(_sToolboxName); 
    	pGPTool = pGPToolbox.OpenTool(_sToolName);
    	return pGPTool;
    }
    
    private string ArcGISInstallFolder
    {
    	get
    	{
    		if (string.IsNullOrEmpty(this.m_sArcGISInstallFolder))
    		{
    		  Microsoft.Win32.RegistryKey regkey;
    		  regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                                                     @"Software\ESRI\ArcGIS", false);
    		  this.m_sArcGISInstallFolder = regkey.GetValue("InstallDir") as String;
    		}
    		return this.m_sArcGISInstallFolder;
    	}
    }
