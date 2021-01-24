    List<string> ItemNames = new List<string>();
    var query1 = from r in new DataTable().AsEnumerable()
                 group r by r.Field<string>("Name") into rr
                 select rr.Key; //its the key of the grouping, i.e. the name
    ItemNames = query1.ToList<string>();
