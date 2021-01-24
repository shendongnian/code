    using (var clientContext = new ClientContext("url"))
    {
        CamlQuery camlQuery = new CamlQuery();
        string query = "add some query here";
        camlQuery.ViewXml = query;
        collListItem = list.GetItems(camlQuery);
        clientContext.Load(collListItem, items => items.Include( item => item["Title"], item => .... // add other columns You need here);
        clientContext.ExecuteQuery();
    
        if (collListItem.Count > 0)
        {
            // Your code here :)
        }
    } 
