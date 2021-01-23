    /// <summary>
    /// Remove cached values from ClientConfigPaths.
    /// Call this after changing path to App.Config.
    /// </summary>
    void ResetConfigMechanism()
    {
    	BindingFlags Flags = BindingFlags::NonPublic | BindingFlags::Static;
    	Type ^cfgType = ConfigurationManager::typeid;
    
    	Int32 ^zero = gcnew Int32(0);
    	cfgType->GetField("s_initState", Flags)
    		->SetValue(nullptr, zero);
    
    	cfgType->GetField("s_configSystem", Flags)
    		->SetValue(nullptr, nullptr);
    
    	for each(System::Type ^t in cfgType->Assembly->GetTypes())
    	{
    		if (t->FullName == "System.Configuration.ClientConfigPaths")
    		{
    			t->GetField("s_current", Flags)->SetValue(nullptr, nullptr);
    		}
    	}
    
    	return;
    }
    
    /// <summary>
    /// Use your own App.Config file instead of the default.
    /// </summary>
    /// <param name="NewAppConfigFullPathName"></param>
    void ChangeAppConfig(String ^NewAppConfigFullPathName)
    {
    	AppDomain::CurrentDomain->SetData(L"APP_CONFIG_FILE", NewAppConfigFullPathName);
    	ResetConfigMechanism();
    	return;
    }
