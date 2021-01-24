                    List mylibrary = ctx.Web.Lists.GetByTitle("Documents");
                    FileCollection files = mylibrary.RootFolder.Folders.GetByUrl("/sites/dev/shared documents/folder1").Files;
    
                    ctx.Load(files);
                    ctx.ExecuteQuery();
    
                    foreach (Microsoft.SharePoint.Client.File file in files)
                    {
                        FileInformation fileinfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, file.ServerRelativeUrl);
    
                        ctx.ExecuteQuery();
    
                        using (FileStream filestream = new FileStream("D:" + "\\" + file.Name, FileMode.Create))
                        {
                            fileinfo.Stream.CopyTo(filestream);
                        }
                        
                    }
                    files.ToList().ForEach(file => file.DeleteObject());
                    ctx.ExecuteQuery();
