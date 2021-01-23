    DataTable dt = ...
    
    var list = 
    dt.AsEnumerable()
    .GroupBy(r => new
    {
        UType = r.Field<string>("UnitType"),
        UZoom = r.Field<string>("UnitZoom"),
        MZoom = r.Field<string>("MemberZoom")
    })
    .Select(g => new Unit 
    { 
        UnitType = g.Key.UType, 
        UnitZoom = g.Key.UZoom, 
        MemberZoom = g.Key.MZoom ,
        MemberIdList = g.Select(r => r.Field<string>("MemberId")).Distinct().ToList()
    })
    .ToList();
