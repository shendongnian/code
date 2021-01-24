        ClientContext ctx = new ClientContext("http://sp/sites/dev");
        List list = ctx.Web.Lists.GetByTitle("MyList");
        Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
      //CamlQuery to filter items which created in Today  
      camlQuery.ViewXml =
           @"<View>  
        <Query> 
           <Where><Eq><FieldRef Name='Created' /><Value Type='DateTime'><Today /></Value></Eq></Where> 
        </Query> 
        </View>";  
        ListItemCollection items = list.GetItems(camlQuery);
        ctx.Load(items);
        ctx.ExecuteQuery();
        User theUser = ctx.Web.EnsureUser("Contoso\\Jerry");
        ctx.Load(theUser);
        ctx.ExecuteQuery();
        foreach (var item in items)
        {
            item["Editor"] = theUser;
            item["Author"] = theUser;
            item.Update();
        }
        ctx.ExecuteQuery();
