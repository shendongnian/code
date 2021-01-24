    var tfsURI = new Uri("http://test:8080/tfs");
    var networkCredential1 = new NetworkCredential("test", "test!");
    
        ICredentials credential = (ICredentials)networkCredential1;
        Microsoft.VisualStudio.Services.Common.WindowsCredential winCred = new Microsoft.VisualStudio.Services.Common.WindowsCredential(credential);
        VssCredentials vssCredentials = new VssCredentials(winCred);
        
        using (TfsTeamProjectCollection collection = new TfsTeamProjectCollection(tfsURI, vssCredentials))
        {
            collection.EnsureAuthenticated();
            TswaClientHyperlinkService hyperlinkService = 
               collection.GetService<TswaClientHyperlinkService>();
            String TFSurl = hyperlinkService.GetWorkItemEditorUrl(17648).ToString(); //17648 WorkItem ID
        }
