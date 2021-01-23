    byte[] rowversion = BitConverter.GetBytes(revision);
    var dbset = (DbSet<TEntity>)context.Set<TEntity>();
    string query = dbset.Where(x => x.Revision != rowversion).ToString()
        .Replace("[Revision] <> @p__linq__0", "[Revision] > @rowversion");
    return dbset.SqlQuery(query, new SqlParameter("rowversion", rowversion)).ToArray();
