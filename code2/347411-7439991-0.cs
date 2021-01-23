    FileStream stream = null;
    try{
        string SiteLocation = "http://abcd.com/sites/forum/";
        SPSecurity.RunWithElevatedPrivileges(delegate(){
            using(SPSite site = new SPSite(SiteLocation)){
                using(SPWeb web = site.OpenWeb()){
                    foreach(SPWeb oweb in web.Webs){
                        bool allowUnsafeUpdates = oWeb.AllowUnsafeUpdates;
                        oWeb.AllowUnsafeUpdates = true;
                        string strFileName = "Mobile.aspx";
                        string strTemplateFileName = "spstd1.aspx";
                        string strPath = "TEMPLATE\\1033\\STS\\DOCTEMP\\SMARTPGS";
                        string hive = SPUtility.GetGenericSetupPath(strPath);
                        //--- Error encountered on this line ---
                        stream = new FileStream(hive + strTemplateFileName,FileMode.Open);
                        //--------------------------------------
                        SPFolder libraryFolder = oWeb.GetFolder(WebPartPageDocLibName);
                        SPFileCollection files = libraryFolder.Files;
                        SPFile newFile = files.Add(strFileName, stream);
                        oWeb.Update();
                        oWeb.AllowUnsafeUpdates = allowUnsafeUpdates;
                    }
                }
            }
        });
    }
    catch(Exception ex)
    {
        // handle or throw your exception 
        // or do any necessary error handling
        throw new Exception(ex.Message,ex);
    }
    finally{
        // it is necessary to dispose your FileStream object to
        // allow access of the file spstd1.aspx on the next usage.
        if(stream!=null) stream.Dispose();
    }
