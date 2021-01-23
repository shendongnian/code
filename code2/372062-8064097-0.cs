    MyEntity entity = from e in objectContext.yourTableName
                      group e by new { e.Col1, e.Col2 } into grp
                      select new MyEntity
                      {
                          _col1 = grp.Key.Col1,
                          _col2 = grp.Key.Col2,
                          _col3 = grp.Select(e => e.Col3).ToList()
                      };
