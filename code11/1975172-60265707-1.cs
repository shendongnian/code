    var joinResult = db.database1.AsEnumerable()
        .Join(NV_DB.database2.AsEnumerable(),    // join list1 and list2
        list1Row => list1Row.CreationDate,       // from every row in list1 take the CreationDate
        list2Row => list2Row.CreationDate,       // from every row in list2 take the CreationDate
        (list1Row, list2Row) => new              // when they match, make one new object
        {
            // You only need the following properties:
            ShipName = list1Item.ShipName,
            CreationDate = list2Item.CreationDate,
            EndingDate = list2Item.EndingDate,
            ShipStatus = list2Item.ShipStatus,
            CustomerNo = list1Item.CustomerNo,
        })
        .ToList();
