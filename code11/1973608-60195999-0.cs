    var ans = Table1.GroupBy(u => "Table1")
                    .Select(ug => new { Name = ug.Key, EntryCount = ug.Count() })
                    .Union(Table2.GroupBy(l => "Table2")
                                  .Select(lg => new { Name = lg.Key, EntryCount = lg.Count() })
                                  .Union(OneRowTable.GroupBy(u2 => 1)
                                                    .Select(u2g => new { Name = "Table2", EntryCount = u2g.Count()-1 }) )
                                  .OrderByDescending(cg => cg.EntryCount)
                                  .Take(1)
                   );
