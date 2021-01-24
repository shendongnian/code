    public SqlResult CreateTradeQuery(Target targets, Group groups, DateTime fromTime)
    {
    	var query = GetDefaultQuery();
    	query.Select("i.Name", "t.Price", "t.Volume");
    	query.Where("t.CreatedDate", ">", fromTime);
    	query.Where(GetSubQuery(targets,groups),"subQuery");
    	SqlResult result = compiler.Compile(query);
    	return result;
    }
    
    private Query GetSubQuery(Target targets, Group groups)
    {
    	var subQuery = GetDefaultQuery();
    	foreach (var target in targets)
    	{
    		subQuery.OrWhere(q => q.WhereIn("i.Name", groups.Keys).WhereIn("i.GroupName", target.Value));
    	}
    	return subQuery;
    }
    
    private Query GetDefaultQuery()
    {
    	var query = new Query("trades as t");
    	query.LeftJoin("info as i","i.Id","t.Id");
    	return query;
    }
