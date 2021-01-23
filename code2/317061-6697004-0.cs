    GetStatus status = workspace.Get(new GetRequest(null, VersionSpec.Latest), GetOptions.Preview);
    
    if(status.NumOperations == 0)
    {
        /* All files up to date. */
    }
    else
    {
        /* We are not up to date on some files. */
    }
