    m_oEngine = New DAO.DBEngine
    
    m_oEngine.SystemDB = sWorkgroupFile
    
    m_oWorkspace = m_oEngine.CreateWorkspace("My Workspace", sUserName, sPassword, DAO.WorkspaceTypeEnum.dbUseJet)
    
    m_oDatabase = m_oWorkspace.OpenDatabase(sDatabaseFile, bExclusive, bReadOnly)  ' Note DAO docs say the second parameter is for Exclusive
