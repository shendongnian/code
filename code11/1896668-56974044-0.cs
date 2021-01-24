    private string GetSchedule()
    {
        string tempPath = Path.GetTempFileName().Replace(".tmp", ".xlsm");
        try
        {
            AuthenticationManager authManager = new OfficeDevPnP.Core.AuthenticationManager();
            ClientContext ctx = authManager.GetWebLoginClientContext("https://oursite.sharepoint.com/sites/ourspecificsite/");
            Web web = ctx.Web;
            Microsoft.SharePoint.Client.File schedule = web.GetFileById(new Guid("ourguid"));
            ctx.Load(web);
            ctx.Load(schedule);
            ctx.ExecuteQuery();
            FileInformation fInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, schedule.ServerRelativeUrl);
            using (var fileStream = File.Create(tempPath))
            {
                fInfo.Stream.CopyTo(fileStream);
            }
        }
        catch (WebException e)
        {
            StatusUpdated?.Invoke(this, new EventArgs<string>(e.Message));
            return null;
        }
        return tempPath;
    }
