    public static IEnumerable<string> GetWebSitesRunningOnApplicationPool(ManagementScope scope, string applicationPoolName)
    {
        //get application names from application pool
        string path = string.Format("IIsApplicationPool.Name='W3SVC/APPPOOLS/{0}'", applicationPoolName);
        ManagementPath managementPath = new ManagementPath(path);
        ManagementObject classInstance = new ManagementObject(scope, managementPath, null);
        ManagementBaseObject outParams = classInstance.InvokeMethod("EnumAppsInPool", null, null);
        //get web server names from application names
        IEnumerable<string> nameList = (outParams.Properties["Applications"].Value as string[]) //no null reference exception even there is no application running
                                       .Where(item => !String.IsNullOrEmpty(item)) //but you get empty strings so they are filtered
                                       .ToList()
                                       .Select(item => item.Slice(item.NthIndexOf("/", 2) + 1, item.NthIndexOf("/", 4))); //your WebServer.Name is between 2nd and 4th slahes
                                        
        //get server comments from names
        List<string> serverCommentList = new List<string>();
        foreach (string name in nameList)
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(scope, new ObjectQuery(string.Format("SELECT ServerComment FROM IIsWebServerSetting WHERE Name = '{0}'", name)));
            serverCommentList.AddRange(from ManagementObject queryObj in searcher.Get() select queryObj["ServerComment"].ToString());
        }
        return serverCommentList;
    }
