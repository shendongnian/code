    var aEnum = TableA.AsEnumerable();
    var bEnum = TableB.AsEnumerable();
    var comp = new SerialNumberComparer();
    from q in bEnum.Except(aEnum,comp).Concat(aEnum.Except(bEnum,comp))
     select new
     {
        SerialNumber = q["SerialNumber"],
        UnitStatus = "HOT",
        PartNumber = q["PartNumber"]
     }
