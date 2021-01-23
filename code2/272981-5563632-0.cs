            [WebMethod]
            public string getLibraries(byte[] contents, String destUrl, string description){
                String message = "1";
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPWeb site = new SPSite(destUrl).OpenWeb();
                    site.AllowUnsafeUpdates = true;
                    message = "2";
                    EnsureParentFolder(site, destUrl);
    
                    site.Files.Add(destUrl, contents);
                    message = "3";
    
                    SPListItem listItem = site.GetListItem(destUrl);
                    listItem["Description"] = description;
                    listItem.Update();
    
                    site.AllowUnsafeUpdates = false;
    
                });
                return message;
            }
