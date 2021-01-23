    var firstNames = new[]
    {
        new { ID = 1, Name = "John" },
        new { ID = 2, Name = "Sue" },
    };
    var lastNames = new[]
    {
        new { ID = 1, Name = "Doe" },
        new { ID = 3, Name = "Smith" },
    };
    var leftOuterJoin = from first in firstNames
                        join last in lastNames
                        on first.ID equals last.ID
                        into temp
                        from last in temp.DefaultIfEmpty(new { first.ID, Name = default(string) })
                        select new
                        {
                            first.ID,
                            FirstName = first.Name,
                            LastName = last.Name,
                        };
    var rightOuterJoin = from last in lastNames
                         join first in firstNames
                         on last.ID equals first.ID
                         into temp
                         from first in temp.DefaultIfEmpty(new { last.ID, Name = default(string) })
                         select new
                         {
                             last.ID,
                             FirstName = first.Name,
                             LastName = last.Name,
                         };
    var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);
