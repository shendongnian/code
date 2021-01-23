    DirectoryEntry iisRoot = new DirectoryEntry("IIS://" + Environment.MachineName + "/W3SVC");
    string webName = "1";
    string virdir = "TestApp1";
    string installpath = @"C:\MyWeb\Application\";
            try
            {
                string iisPath = string.Format("IIS://{0}/W3SVC/{1}/Root", Environment.MachineName, webName);
                Console.WriteLine(iisPath);
                iisRoot = new DirectoryEntry(iisPath);
                DirectoryEntry vdir = iisRoot.Children.Add(virdir, iisRoot.SchemaClassName);
                vdir.Properties["Path"][0] = installpath;
                vdir.Properties["EnableDefaultDoc"][0] = true;
                vdir.Properties["DefaultDoc"][0] = "Login.aspx,default.htm,default.aspx,default.asp";
                vdir.Properties["AspEnableParentPaths"][0] = true;
                vdir.CommitChanges();
                vdir.Invoke("AppCreate", true);
                vdir.Properties["AppFriendlyName"][0] = virdir;
                vdir.CommitChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Message + "\n" + e.StackTrace);
            }
