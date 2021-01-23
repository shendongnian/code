    Expression<Func<SomeEfPoco, bool>> columnBeingFilteredPredicate = x => true; // Default expression to just say yes
    if (!string.IsNullOrWhiteSpace(someColumnBeingFilteredValue))
    {
        columnBeingFilteredPredicate = x => x.someColumnBeingFiltered == someColumnBeingFilteredValue;
    }
    
    _context.SomeEfPocos.Where(x => ..... &&
                ..... &&
                ..... &&)
    .Where(columnBeingFilteredPredicate);
