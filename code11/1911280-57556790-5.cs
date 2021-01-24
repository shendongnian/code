    var query = fullTable
                   .AsEnumerable()
                   .Select(x => new
                       {
                           PartnerID = x.Field<string>("PartnerID"),
                           PartnerName = x.Field<string>("Partner Name")
                       }
                   ).Distinct();
        
    foreach(var t in query)
    {
        Console.WriteLine(t.PartnerID + " " + t.PartnerName);
    }
