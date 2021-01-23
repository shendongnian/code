    using (SPSite site = new SPSite("http://localhost"))
    {
        using (SPWeb web = site.OpenWeb())
        {
            SPContentType contentType = new SPContentType(web.ContentTypes["Document"], web.ContentTypes, "Financial Document");
            web.ContentTypes.Add(contentType);
            contentType.Group = "Financial Content Types";
            contentType.Description = "Base financial content type";
            contentType.FieldLinks.Add(new SPFieldLink(web.Fields.GetField("OrderDate")));
            contentType.FieldLinks.Add(new SPFieldLink(web.Fields.GetField("Amount")));
            contentType.Update();
        }
    }
