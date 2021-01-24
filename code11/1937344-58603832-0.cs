    (
        e.Entity != null && e.Entity.ListA != null && e.Entity.ListB != null
            ? e.Entity.ListA.Union(e.Entity.ListB)
            : e.Entity != null && e.Entity.ListA != null
                ? e.Entity.ListA
                : e.Entity.ListB != null
                    ? e.Entity.ListB
                    : new Entity[0]
    ).Any(...)
