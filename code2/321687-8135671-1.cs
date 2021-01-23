     if (objWeb.IsRootWeb)
     {   
        SPContentType contentType = objWeb.ContentTypes["Wiki Page"];
        if (!contentType.Fields.ContainsField("Keywords"))
        {
          SPField field = objWeb.Fields["Keywords"];
          SPFieldLink fieldLink = new SPFieldLink(field);
          contentType.FieldLinks.Add(fieldLink);
          contentType.Update(true);
        }
     }
     else
     {
       SPContentType contentTyperoot = site.RootWeb.ContentTypes["Wiki Page"];
       if (!contentTyperoot.Fields.ContainsField("Keywords"))
       {
         SPContentType contentType = site.RootWeb.ContentTypes["Wiki Page"];
         if (!contentType.Fields.ContainsField("Keywords"))
         {
           SPField field = site.RootWeb.Fields["Keywords"];
           SPFieldLink fieldLink = new SPFieldLink(field);
           contentType.FieldLinks.Add(fieldLink);
           contentType.Update(true);
         }
       }
     }
