    IEnumerable<IGrouping<int, EbrRecord>> query = ...
      orderby Location, RepName, AccountID
      select new EbrRecord(
        AccountID = EbrData[0],
        AccountName = EbrData[1],
        MBSegment = EbrData[2],
        RepName = EbrData[4],
        Location = EbrData[7],
        TsrLocation = EbrData[8]) into x
      group x by new {Location = x.Location, RepName = x.RepName} into g
      from y in g.Select((data, index) => new Record = data, Index = index })
      group y.Record by y.Index/100;
