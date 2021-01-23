    for (int i = 0; i < Phase.Count; i++)
    { 
        if (i > 0) { query+= " || "; }
        query += string.Format("Phase == {0}", lstObjects[i].Value);
    }
    context.MyList.Where(query);
