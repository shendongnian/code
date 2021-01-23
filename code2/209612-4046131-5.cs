    public IQueryable<Product> Search(Dictionary<string, string> searchParams)
    {
        DBDataContext dc = new DBDataContext();
    
        StringBuilder sQuery = new StringBuilder();
        foreach (KeyValuePair<string, string> temp in searchParams)
        {
            if( sQuery.Length > 0 ) sQuery.Append(" AND ");
            sQuery.AppendFormat("{0}={1}",temp.Key,temp.Value);
        }
    
        var query = dc.Products.Where(sQuery.ToString());
    
        return query;
    }
