    var groupedCollection = table.AsEnumerable()
                                        .GroupBy(row => new
                                        {
                                            UType = row.Field<string>("UnitType"),
                                            UZoom = row.Field<string>("UnitZoom"),
                                            MZoom = row.Field<string>("MemberZoom") 
                                        });         
                var unitCollection = groupedCollection
                                    .Select(g => new Unit 
                                    {
                                        UnitType = g.Key.UType,
                                        UnitZoom = g.Key.UZoom,
                                        MemberZoom = g.Key.MZoom,                                   
                                        MemberIdList = g.OrderBy(b => b..Field<int>("MemberOrder").Select(r => r.Field<string>("MemberId")).ToList(),
                                    });
                List<Unit> units = unitCollection.ToList();
