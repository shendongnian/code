            using (ClientContext ctx=new ClientContext("http://sp/sites/dev/"))
            {
                List list = ctx.Web.Lists.GetByTitle("MyList22");
                CamlQuery caml = new CamlQuery();
                caml.ViewXml = "<View><Query><Where><Eq><FieldRef Name='myLookupField' LookupId='TRUE'/><Value Type='Lookup'>1</Value></Eq></Where></Query></View>";
                ListItemCollection items = list.GetItems(caml);
                ctx.Load(items);
                ctx.ExecuteQuery();
                foreach (ListItem item in items)
                {
                    FieldLookupValue value = item["myLookupField"] as FieldLookupValue;
                    Console.WriteLine("LookupId: "+ value.LookupId);
                    Console.WriteLine("LookupValue: "+ value.LookupValue);
                }
            }
