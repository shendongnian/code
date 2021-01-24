    string lastExecutionDate = targetDate.ToString("yyyyMMddHHmmss");
    string lastExecutionMs = targetDate.ToUniversalTime().Subtract(
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        ).TotalMilliseconds.ToString();
    var terminalKeys = terminals.Keys.ToList(); // You probably cannot use ContainsKey in Linq2EF...
    var sales = context.SALES
        .Where(s => terminalKeys.Contains(s.SC_TERM)
           && ((s.SC_TIMESTAMP.Length == 14 && s.SC_TIMESTAMP > lastExecutionDate) 
              || (s.SC_TIMESTAMP.Length != 14 && s.SC_TIMESTAMP > lastExecutionMs)))
        .Select(s =>
           new Sale 
           {
               Product = s.SC_PRDCT,
               Terminal = s.SC_TERM,
               Operator = s.MC_OP,
               UnixString = s.SC_TIMESTAMP
           }).ToList();
