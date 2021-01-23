    if (Currentval == Value1)
    {
        val1 = ((IQueryable<ATable>)val).Where(c => c.Id == 2);
    }
    else if (Currentval == Value1)
    {
        val1 = ((IQueryable<Book>)val).Where(c => c.BookId == 3);
    }
