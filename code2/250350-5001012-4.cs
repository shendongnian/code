    var list = new List<Tuple<Predicate<MyCustomType>, string>>
    {
        Tuple.Create(dc => true, Constant.CD_1),
        Tuple.Create(dc => true, Constant.CD_2),
        Tuple.Create(dc => true, Constant.CD_3),
        Tuple.Create(dc => dc.primaryZone != null, Constant.CD_4),
        Tuple.Create(dc => dc.Mgr1 != null, Constant.CD_5),
        // etc
    };
