    ClientContext ctx = new ClientContext("http://yoursite");
    List list = ctx.Web.Lists.GetByTitle("ListName");
    ListItemCollection items = list.GetItems(CamlQuery.CreateAllItemsQuery());
    ctx.Load(items); // loading all the fields
    ctx.ExecuteQuery();
    foreach(var item in items)
    {
        // important thing is, that here you must have the right type
        // i.e. item["Modified"] is DateTime
        item["fieldName"] = newValue;
        
        // do whatever changes you want
        item.Update(); // important, rembeber changes
    }
    ctx.ExecuteQuery(); // important, commit changes to the server
