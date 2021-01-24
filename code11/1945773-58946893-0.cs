    public static List<WhiteList> CreateObjects(XDocument xmldoc)
    {
        var query = from data in xmldoc.Descendants("whitelist")
                    select new WhiteList
                    {
                        ID = (string)data.Element("id"),
                        From = (string)data.Element("from"),
                        To = (string)data.Element("to"),
                    };
    
        var list = query.ToList();
        List<WhiteList> result = new List<WhiteList>();
        // now create the desierd list
        foreach (var x in list)
        {
            WhiteList ws = new WhiteList();
            ws.ID = x.ID;
            ws.From = x.From;
            ws.To = x.To;
            result.Add(ws);
        }
    
        return result;
    }
