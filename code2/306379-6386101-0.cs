    using System.Net;
    using Microsoft.SharePoint.Client;
    using (ClientContext context = new ClientContext("http://yourserver/")) {
        context.Credentials = new NetworkCredential("user", "password", "domain");
        List list = context.Web.Lists.GetByTitle("Some List");
        context.ExecuteQuery();
        // Now update the list.
    }
