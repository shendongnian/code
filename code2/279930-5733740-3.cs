    var result = from results in sortedData.AsEnumerable()
                 group results by results.animal into grp
                 let sortedGrp = grp.OrderBy(c => c.operationDate)
                                    .ToList()
                 select new
                 {
                    animal = grp.Key,
                    study = ??,
                    groupNumber = ??,
                    TGI  = sortedGrp.Last().volume  - sortedGrp.First().volume               
                 };
 
