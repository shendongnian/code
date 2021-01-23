    var gameCounts = _oListGames
                     .GroupBy(p => p.Visitor)
                     .Select(group =>
                         new
                         {
                             TeamID = group.Key,
                             Count = group.Count()
                         }
                     );
