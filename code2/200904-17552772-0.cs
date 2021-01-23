        System.Management.ConnectionOptions connOptions = new System.Management.ConnectionOptions();
        System.Collections.Generic.List<string> sessionIDs = new System.Collections.Generic.List<string>();
        connOptions.Impersonation = System.Management.ImpersonationLevel.Impersonate;
        connOptions.EnablePrivileges = true;
        try
        {
            //Use "." for the local computer, or a computer name or IP address for a remote computer.
            string compName = ".";
            System.Management.ManagementScope manScope =
                new System.Management.ManagementScope(
                    String.Format(@"\\{0}\ROOT\CIMV2", compName), connOptions);
            manScope.Connect();
            System.Management.SelectQuery selectQuery = new System.Management.SelectQuery("Select SessionId from Win32_Process");
            using (System.Management.ManagementObjectSearcher searcher =
            new System.Management.ManagementObjectSearcher(manScope, selectQuery))
            {
                foreach (System.Management.ManagementObject proc in searcher.Get())
                {
                    string id = proc["SessionId"].ToString();
                    //Skip session 0, which is the system session.
                    if (id != "0")
                    {
                        sessionIDs.Add(id);
                    }
                }
            }
            //remove the dups.
            sessionIDs = sessionIDs.Distinct().ToList();
            foreach (string id in sessionIDs)
            {
                System.Diagnostics.Debug.Print(id);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
        }
