    addressDic = mainDiagram.Elements.Where(x=>x.SubType == EElemSubType.BusBar)
                        .Where(x=>connPts.Busbars.ContainsKey(x.ConnectionPointId))
                        .GroupBy(x=>x.Key)
                        .Select(x=>new TAddress{Key = x.Key,
                                Value = connPts.Busbars[x.Last().ConnectionPointId]})
                        .ToDictionary(x=>x.Key);
