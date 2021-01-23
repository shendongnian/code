    private ISessionFactory BuildSessionFactory(bool useOracleMapping)
    {
        Configuration config = new Configuration();
    
        config.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider, "...");
        config.SetProperty(NHibernate.Cfg.Environment.Dialect, "...");
        config.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "...");
        config.SetProperty(NHibernate.Cfg.Environment.ConnectionString, "...");
        config.SetProperty(NHibernate.Cfg.Environment.Isolation, "Serializable");
        config.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass, "...");
        config.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
        config.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, "none");
    
        // filter hbm Files
    
        // Set reference to entity assembly
        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(MyEntity));
    
        // get Resource-files
        string[] resources = assembly.GetManifestResourceNames();
    
        // scan through all the hbm files and filter them according to the parameter
        foreach (string hbmFile in resources)
        {
            // This filtering here could probably be done simpler, but this is easy to understand
            bool addFile = false;
            // ignore any file that does not end with .hbm.xml
            if (hbmFile.EndsWith(".hbm.xml"))
            {
                if (hbmFile.ToLower().EndsWith(".default.hbm.xml"))
                {
                    if (!useOracleMapping)
                    {
                        // we want that file for this SessionFactory
                        addFile = true;
                    }
                }
                else if (hbmFile.ToLower().EndsWith(".oracle.hbm.xml"))
                {
                    if (useOracleMapping)
                    {
                        // we want that file for this SessionFactory
                        addFile = true;
                    }
                }
                else
                {
                    // neither default nor oracle -> we want that file no matter what
                    addFile = true;
                }
                if (addFile)
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(assembly.GetManifestResourceStream(hbmFile)))
                    {
                        string resourceContent = sr.ReadToEnd();
                        config.AddXmlString(resourceContent);
                    }
                }
            }
        }
    
        // create Sessionfactory with the files we filtered
        ISessionFactory sessionFactory = config.BuildSessionFactory();
        return sessionFactory;
    }
