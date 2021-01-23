    DateTime today = DateTime.Now;
    var events = context.Events
                        .Where(e => e.DueDate >= today)
                        .OrderBy(e => System.Data.Objects.SqlClient.SqlFunctions.DateDiff("d", e.DueDate, today))
                        .Take(5)
                        .ToList();
