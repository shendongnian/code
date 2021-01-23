    ObjectQuery<DbDataRecord> query = context.TestEnt.Select("it.BuySell, it.DepoTerm")
        .Where("DiffDays(it.[RunDateTime],cast('22-11-2012' as System.DateTime))=0");
    var a = query.ToList();
    foreach (var tmp in a)
    {
        Console.WriteLine(tmp["BuySell"].ToString());
    }
