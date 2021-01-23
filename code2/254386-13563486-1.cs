    private static string tfsServer = @"http://tfsserver.org:8080/tfs";
    internal static bool CheckOutFromTFS(string fileName)
    {
        bool retval = false;
        try
        {        
            using (TfsTeamProjectCollection pc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(tfsServer)))        
            {
                if (pc != null)
                {
                    WorkspaceInfo workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(fileName);
                    if (null != workspaceInfo)
                    {                   
                        Workspace workspace = workspaceInfo.GetWorkspace(pc);
                        workspace.PendEdit(fileName);
                    }
                }
            }
    
            FileInfo fi = new FileInfo(fileName);
            retval = !fi.IsReadOnly;
        }
        catch
        {
            retval = false;
        }
        return retval;
    }   
