    using (var context = new ClientContext("sit url"))
    {
        context.Credentials = credentials;
        
        var groupOwner = context.Web.SiteGroups.GetByName("GroupName"); 
        ctx.ExecuteQuery();     
    }
