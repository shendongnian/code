    IEnumerable<Employee> activeAuditOwners = objectStateEntries
      .Select(s => s.Entity)
      .OfType<IAuditEntry>()
      ,Where(e => e.Active)
      .Select(e => e.Owner);
