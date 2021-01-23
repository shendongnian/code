    var result = tableData.GroupBy(row => new { row.Folder, row.User })
                          .Select(g => new {
                                      Folder = g.Key.Folder,
                                      User = g.Key.Folder,
                                      P1 = g.Any(row => row.P1),
                                      P2 = g.Any(row => row.P2),
                                      P3 = g.Any(row => row.P3)
                                  });
