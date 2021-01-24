/// <summary>
      /// This procedure uploads documents to the Authorizations Library
      /// </summary>
      /// <param name="filename">File Being Uploaded</param>
      /// <param name="p">file in bytes</param>
      /// <param name="library">Library to upload to</param>
      /// <returns></returns>
        private string UploadToSharePoint(string filename, byte[] p,string library)  //p is path to file to load
        {
            string newUrl;
            string siteUrl = string.Empty; 
             
            
            siteUrl = qsURL + @"/repository/current/";
            // Calculate block size in bytes.
            int blockSize = fileChunkSizeInMB * 1024 * 1024;
            //Insert Credentials
             Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(siteUrl);
            context.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            Microsoft.SharePoint.Client.Web site = context.Web;
            if (context.HasPendingRequest)
                context.ExecuteQuery();
            try
            {
                //Get the required RootFolder
                string barRootFolderRelativeUrl = library;
                // Getting Folder List to see if EQCode Folder Exists  If not create it.
                string eq = txtEQCode.Text;
                FolderCollection folders = site.GetFolderByServerRelativeUrl(barRootFolderRelativeUrl).Folders;   //list.RootFolder.Folders;
                context.Load(folders, fl => fl.Include(ct => ct.Name)
                .Where(ct => ct.Name == eq));
                context.ExecuteQuery();
                if (folders.Count < 1)  // Create Folder because it does not exist on SharePoint Library
                {
                    folders.Add(eq);
                    context.ExecuteQuery();
                }
                Microsoft.SharePoint.Client.Folder barFolder = site.GetFolderByServerRelativeUrl(barRootFolderRelativeUrl);
                Microsoft.SharePoint.Client.Folder currentRunFolder = site.GetFolderByServerRelativeUrl(barRootFolderRelativeUrl + "/" + eq);
                //Microsoft.SharePoint.Client.FileCreationInformation newFile = new Microsoft.SharePoint.Client.FileCreationInformation { Content = p, Url = filename, Overwrite = true };
                //Microsoft.SharePoint.Client.File uploadFile = currentRunFolder.Files.Add(newFile);
                MemoryStream stream = new MemoryStream(p);
                FileCreationInformation flciNewFile = new FileCreationInformation();
                // This is the key difference for the first case – using ContentStream property
                flciNewFile.ContentStream = stream;
                flciNewFile.Url = System.IO.Path.GetFileName(fixInvalidCharactersInFileName(filename));
                flciNewFile.Overwrite = false;
                Microsoft.SharePoint.Client.File uploadFile = currentRunFolder.Files.Add(flciNewFile);
                currentRunFolder.Update();
                context.Load(uploadFile);
                context.ExecuteQuery();
                newUrl = siteUrl + barRootFolderRelativeUrl + "/" + filename;
                // Set document properties
                // Have to check out document to upldate properties.
                uploadFile.CheckOut();
                Microsoft.SharePoint.Client.ListItem listItem = uploadFile.ListItemAllFields;
                // Sets up ListItem fields based on Content Type 
                // as each content type has a different set of Required Fields.
                SetUpListItems(listItem, EQCode);
                listItem["Title"] = filename;
                listItem.Update();
                uploadFile.CheckIn("File Uploaded Manually added metadata", Microsoft.SharePoint.Client.CheckinType.MinorCheckIn);
                context.ExecuteQuery();
                //Return the URL of the new uploaded file
                return newUrl;
            }
            catch (Exception e)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Error Uploading!", "alert('" + e.Message + "');", true);
                return "FALSE";
            }
        }
