                ClientContext ctx = new ClientContext("http://sp/sites/dev/");
                List list = ctx.Web.Lists.GetByTitle("dccc");
                CamlQuery caml = new CamlQuery();
                ListItemCollection items = list.GetItems(caml);
                ctx.Load(items);
                ctx.ExecuteQuery();
                foreach (ListItem item in items)
                {
    
                    switch (item.FileSystemObjectType)
                    {
                        case FileSystemObjectType.File:
                            ctx.Load(item, i => i.File);
                            ctx.ExecuteQuery();
                            if (item.File.Exists)
                            {
                                Console.WriteLine(item.File.Name);
                            }
                            break;
                    }
                }
