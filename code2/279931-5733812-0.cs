    var result = 
        from results in sortedData.AsEnumerable()
        group results by new
        {
         Animal = results.animal,
         Study = results.study,
         GroupNumber = results.groupNumber 
        }
        into grp
        select new
        {
             animal = grp.Key.Animal,
             study = grp.Key.Study,
             groupNumber = grp.Key.GroupNumber,
             TGI = System.Math.Log(grp.OrderByDescending(c=>c.operationDate).First().volume)
                               
                 - System.Math.Log(grp.OrderBy(c=>c.operationDate).First().volume)
        };
