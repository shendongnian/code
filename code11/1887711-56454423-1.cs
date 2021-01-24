    var query =
        from c in dt.AsEnumerable()
        join lookup in lookupDt.AsEnumerable() on c.Field<int>("Campaign ID") equals lookup.Field<int>("EventID”) into clookup
        from lookup in clookup.DefaultIfEmpty()
        select new { 
          CampaignID = c.Field<int>(“Campaign ID”),
          Number = c.Field<int>(“Number”),
          Name = c.Field<string>(“Name”) };
    var table = query.CopyToDatatable();
