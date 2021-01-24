     static void Main(string[] args)
        {
            ListItemCollection items = GetItems();
            foreach (ListItem item in items)
            {
                Console.WriteLine(item["Title"]);
            }
           
                
        }
        private static ListItemCollection GetItems()
        {
            ClientContext context = new ClientContext("http://sp/sites/Jerry");
    
            List ChangeList = context.Web.Lists.GetByTitle("TestList");
            CamlQuery query = CamlQuery.CreateAllItemsQuery(1505);
    
            ListItemCollection items = ChangeList.GetItems(query);
            context.Load(items);
            context.ExecuteQuery();
            return items;
        }
