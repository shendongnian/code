    public override string BuildPagedSelectStatement()
    {
        int startnum = query.PageSize * query.CurrentPage + 1;
        int endnum = query.PageSize * query.CurrentPage + query.PageSize;
        string orderBy = String.Empty;
        if (this.query.OrderBys.Count > 0)
            orderBy = GenerateOrderBy();
        //The ROW_NUMBER() function in Oracle requires an ORDER BY clause.
        //In case one is not specified, we need to halt and inform the caller.
        if(orderBy.Equals(String.Empty))
            throw new ArgumentException("There is no column specified for the ORDER BY clause", "OrderBys");
        
        System.Text.StringBuilder sql = new System.Text.StringBuilder();
        //Build the command string
        sql.Append("WITH pagedtable AS (");
        sql.Append(GenerateCommandLine());
        
        //Since this class is for Oracle-specific SQL, we can add a hint
        //which should help pagination queries return rows more quickly.
        //AFAIK, this is only valid for Oracle 9i or newer.
        sql.Replace("SELECT", "SELECT /*+ first_rows('" + query.PageSize + "') */");
        
        sql.Append(", ROW_NUMBER () OVER (");
        sql.Append(orderBy);
        sql.Append(") AS rowindex ");
        sql.Append(Environment.NewLine);
        sql.Append(GenerateFromList());
        sql.Append(GenerateJoins());
        sql.Append(GenerateWhere());
        if (query.Aggregates.Count > 0)
        {
            sql.Append(GenerateGroupBy());
            sql.Append(Environment.NewLine);
            sql.Append(GenerateHaving());
        }
        sql.Append(") SELECT * FROM pagedtable WHERE rowindex >= ");
        sql.Append(startnum);
        sql.Append(" AND rowindex < ");
        sql.Append(endnum);
        sql.Append(" ORDER BY rowindex");
        return sql.ToString();
    }
