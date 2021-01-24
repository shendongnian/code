     ClientContext context = new ClientContext(@"http://SP13");
                List list = context.Web.Lists.GetByTitle("List23");
                ListItemCollection items = list.GetItems(CamlQuery.CreateAllItemsQuery());
                
                context.Load(items, item => item.Include(i => i["Title"], i => i["richtext"]));
                context.ExecuteQuery();
