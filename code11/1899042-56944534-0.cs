    using(var context=new ClientContext("http://sp"))
                {
                    var web = context.Web;
                    var list = web.Lists.GetByTitle("MyList");
                    var item = list.GetItemById(1);
                    context.Load(web);
                    context.Load(item);
                    context.ExecuteQuery();
                    var fileLink = item["Document_Link"] as FieldUrlValue;
    
                    var file = web.GetFileByServerRelativeUrl(fileLink.Url.Replace(web.Url,""));
                    context.Load(file);
                    context.ExecuteQuery();
                    //to do
                    //var stream = file.OpenBinaryStream();
                    Console.WriteLine("complete");
                }
