    if (Currentval == Value1)
    {
        val1 = ((IQueryable<UniqueTable1>)val).Where(c => c.Id == 2);
    }
    else if (Currentval == Value1)
    {
        val1 = ((IQueryable<UniqueTable2>)val).Where(c => c.Id == 3);
    }
