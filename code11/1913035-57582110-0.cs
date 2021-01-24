    var query =
        from x in data
        group new { x.StockId, x.StockName, x.Prices, x.ScreenNumber }
            by new { x.GroupId, x.GroupName, x.SubGroupId1, x.SubGroupName1, x.SubGroupId2, x.SubGroupName2 }
            into g
        group g
            by new { g.Key.GroupId, g.Key.GroupName, g.Key.SubGroupId1, g.Key.SubGroupName1 }
            into g2
        group g2
            by new { g2.Key.GroupId, g2.Key.GroupName }
            into g1
        select new
        {
            Id = g1.Key.GroupId,
            Name = g1.Key.GroupName,
            SubGroup1 = g1.Select(g2 => new
            {
                Id = g2.Key.SubGroupId1,
                Name = g2.Key.SubGroupName1,
                SubGroup2 = g2.Select(g => new
                {
                    Id = g.Key.SubGroupId2,
                    Name = g.Key.SubGroupName2,
                    Items = g.Select(x => new
                    {
                        x.StockId,
                        x.StockName,
                        x.Prices,
                        x.ScreenNumber,
                    }),
                }),
            }),
        };
