    var query = (from r in db.Regions
                 join c in db.Countries on r.RegionID equals c.RegionId
                 join i in db.Programs on c.CountryID equals i.CountryID
                 select new { r.RegionID, r.RegionName })
                .Distinct();
    // get the enumerator
    var enumerator = query.GetEnumerator();
    enumerator.Reset();
    while(enumerator.MoveNext()){
        var obj = enumerator.Current;
        // you can now use the query's anonymous properties
    }
  
