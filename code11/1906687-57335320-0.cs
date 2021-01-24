    var contains = list.Aggregate(new System.Text.StringBuilder(),
                                  (sb, s) => sb.Append($"N'{s}', "),
                                  sb => (sb.Length > 0)
                                          ? sb.ToString(0, sb.Length - 2)
                                          : null);
    if (contains == null)
    {
      //ToDo: list is empty, we've got a problem
    }
    else
    {
      var query = testDB.Items.SqlQuery($@"SELECT [E1].[Id],..
                                         FROM [testDB].[Items] AS [E1]
                                         WHERE CONCAT_WS(':', [E1].[Id],..) IN ({contains })");
    }
