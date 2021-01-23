        var clientContext = (ClientContext)file.Context;
        destinationWebContext.Load(destinationList, d => d.ParentWebUrl);
        destinationWebContext.Load(destinationList, d => d.RootFolder.ServerRelativeUrl);
        clientContext.Load(file, f => f.ServerRelativeUrl);
        clientContext.Load(file, f => f.Name);
    
        if (clientContext.HasPendingRequest)
           clientContext.ExecuteQueryRetry();
    
        if (destinationWebContext.HasPendingRequest)
            destinationWebContext.ExecuteQueryRetry();
    
        var location = string.Format("{1}/{2}", destinationList.ParentWebUrl, destinationList.RootFolder.ServerRelativeUrl, file.Name);
        var fileInfo = File.OpenBinaryDirect(clientContext, file.ServerRelativeUrl);
        File.SaveBinaryDirect(destinationWebContext, location, fileInfo.Stream, overwrite);
    
        File newFile = destinationWebContext.Web.GetFileByServerRelativeUrl(location);
        newFile.CheckIn("Checked in by provisioning service", Microsoft.SharePoint.Client.CheckinType.MajorCheckIn);
        destinationWebContext.ExecuteQuery();
