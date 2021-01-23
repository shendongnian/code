    var myObject =Enumerable.Empty<RowType>.Select(row=>select new {columnA, columnB, columnC});
    if(city == "New York City")
    {
      myObject= from x in MyEFTable
                         where x.CostOfLiving == "VERY HIGH"
                         select select new {columnA, columnB, columnC};
    }
    else
    {
      myObject = from x in MyEFTable
                         where x.CostOfLiving == "MODERATE"
                         select select new {columnA, columnB, columnC};
    }
