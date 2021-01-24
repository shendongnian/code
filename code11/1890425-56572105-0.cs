    using (ClientContext ctx = new ClientContext(targetSiteURL))
                {
                    ctx.Credentials = onlineCredentials;
    
                    string fileName = "FileWith#%.docx";
                    var _File = ctx.Web.GetFileByServerRelativePath(ResourcePath.FromDecodedUrl($"/sites/lee/MyDoc/{fileName}"));
                    ctx.Load(_File);
                    ctx.ExecuteQuery();
                    Console.Write(_File.ServerRelativeUrl);
                    Console.WriteLine();
                }
