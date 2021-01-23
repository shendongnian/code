    IQueryable<RowType> partialQuery;
    if(city == "New York City")
        partialQuery=MyEFTable.Where(x=>x.x.CostOfLiving == "VERY HIGH");
    else
        partialQuery=MyEFTable.Where(x=>x.x.CostOfLiving == "MODERATE");
    var myObject=partialQuery.Select(x=>x.new {columnA, columnB, columnC});
