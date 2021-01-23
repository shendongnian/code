    private static List GetListByServerRelativeUrl(string serverRelativeUrl)
        {
            using (ClientContext ctx = new ClientContext("http://yoursite"))
            {
                var q = from list in ctx.Web.Lists
                        where list.RootFolder.ServerRelativeUrl == serverRelativeUrl
                        select list;
                var r = ctx.LoadQuery(q);
                ctx.ExecuteQuery();
                return r;
            }
        }
