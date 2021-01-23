    /// <summary>
    /// Create a Full Storage through .NET code
    /// </summary>
    private void CreateFullStorage()
    {
        // USER MUST BE A MEMBER OF SQL DATABASE ROLE: NetSqlAzMan_Administrators
        //Sql Storage connection string
        string sqlConnectionString = "data source=(local);initial catalog=NetSqlAzManStorage;user id=netsqlazmanuser;password=password";
        //Create an instance of SqlAzManStorage class
        IAzManStorage storage = new SqlAzManStorage(sqlConnectionString);
        //Open Storage Connection
        storage.OpenConnection();
        //Begin a new Transaction
        storage.BeginTransaction(AzManIsolationLevel.ReadUncommitted);
        //Create a new Store
        IAzManStore newStore = storage.CreateStore("My Store", "Store description");
        //Create a new Basic StoreGroup
        IAzManStoreGroup newStoreGroup = newStore.CreateStoreGroup(SqlAzManSID.NewSqlAzManSid(), "My Store Group", "Store Group Description", String.Empty, GroupType.Basic);
        //Retrieve current user SID
        IAzManSid mySid = new SqlAzManSID(WindowsIdentity.GetCurrent().User);
        //Add myself as sid of "My Store Group"
        IAzManStoreGroupMember storeGroupMember = newStoreGroup.CreateStoreGroupMember(mySid, WhereDefined.Local, true);
        //Create a new Application
        IAzManApplication newApp = newStore.CreateApplication("New Application", "Application description");
        //Create a new Role
        IAzManItem newRole = newApp.CreateItem("New Role", "Role description", ItemType.Role);
        //Create a new Task
        IAzManItem newTask = newApp.CreateItem("New Task", "Task description", ItemType.Task);
        //Create a new Operation
        IAzManItem newOp = newApp.CreateItem("New Operation", "Operation description", ItemType.Operation);
        //Add "New Operation" as a sid of "New Task"
        newTask.AddMember(newOp);
        //Add "New Task" as a sid of "New Role"
        newRole.AddMember(newTask);
        //Create an authorization for myself on "New Role"
        IAzManAuthorization auth = newRole.CreateAuthorization(mySid, WhereDefined.Local, mySid, WhereDefined.Local, AuthorizationType.AllowWithDelegation, null, null);
        //Create a custom attribute
        IAzManAttribute<IAzManAuthorization> attr = auth.CreateAttribute("New Key", "New Value");
        //Create an authorization for DB User "Andrea" on "New Role"
        IAzManAuthorization auth2 = newRole.CreateAuthorization(mySid, WhereDefined.Local, storage.GetDBUser("Andrea").CustomSid, WhereDefined.Local, AuthorizationType.AllowWithDelegation, null, null);
        //Commit transaction
        storage.CommitTransaction();
        //Close connection
        storage.CloseConnection();
    }
    
