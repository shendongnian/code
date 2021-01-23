    var result = from row in dt.AsEnumerable()
                  group row by row.Field<int>("TeamID") into grp
                   select new
                     {
                     TeamID = grp.Key,
                      MemberCount = grp.Count()
                      };
     foreach (var t in result)
         Console.WriteLine(t.TeamID + " " + t.MemberCount);
