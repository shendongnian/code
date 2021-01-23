    // connection string
    SCConnectionStringBuilder scBuilder = new SCConnectionStringBuilder();
    scBuilder.Authenticate = true;
    scBuilder.IsPrimaryLogin = true;
    scBuilder.Integrated = true;
    scBuilder.Host = "localhost";
    scBuilder.Port = 5555;
    // connect to K2 Server
    WorkflowManagementServer wfmServer = new WorkflowManagementServer();
    
    wfmServer.CreateConnection();
    wfmServer.Connection.Open(scBuilder.ConnectionString);
    
    // optionally get a list of process instances to explore
    /*
    ProcessInstances procInst = 
      wfmServer.GetProcessInstancesAll(string.Empty, string.Empty, string.Empty);
    */
    
    // when you've got a proc inst you're interested in, stop it.
    int _procInstId = 123; // get this from your process instance context
    wfmServer.StopProcessInstances(_procInstId);
