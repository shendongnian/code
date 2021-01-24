            ClientContext ctx = new ClientContext("http://sp/sites/dev");
            List list = ctx.Web.Lists.GetByTitle("MyList");
			ListItemCollection items = list.GetItems(CamlQuery.CreateAllItemsQuery());
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
