    // first
    from c in context.Con
    where ( c.Col1 == c.Col2 || c.Col3 == c.Col4 )
    select c;
    
    // second
    context.Con.Where(c => c.Col1 == c.Col2 || c.Col3 == c.Col4);
