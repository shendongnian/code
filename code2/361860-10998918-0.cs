    int Insert<T>(IQueryable query,IQueryable<T> targetSet)
    {
        var oQuery=(ObjectQuery)this.QueryProvider.CreateQuery(query.Expression);
        var sql=oQuery.ToTraceString();
        var propertyPositions = GetPropertyPositions(oQuery);
 
        var targetSql=((ObjectQuery)targetSet).ToTraceString();
        var queryParams=oQuery.Parameters.ToArray();
        System.Diagnostics.Debug.Assert(targetSql.StartsWith("SELECT"));
        var queryProperties=query.ElementType.GetProperties();
        var selectParams=sql.Substring(0,sql.IndexOf("FROM "));
        var selectAliases=Regex.Matches(selectParams,@"\sAS \[([a-zA-Z0-9_]+)\]").Cast<Match>().Select(m=>m.Groups[1].Value).ToArray();
         
        var from=targetSql.Substring(targetSql.LastIndexOf("FROM [")+("FROM [".Length-1));
        var fromAlias=from.Substring(from.LastIndexOf("AS ")+"AS ".Length);
        var target=targetSql.Substring(0,targetSql.LastIndexOf("FROM ["));
        target=target.Replace("SELECT","INSERT INTO "+from+" (")+")";
        target=target.Replace(fromAlias+".",string.Empty);
        target=Regex.Replace(target,@"\sAS \[[a-zA-z0-9]+\]",string.Empty);
        var insertParams=target.Substring(target.IndexOf('('));
        target = target.Substring(0, target.IndexOf('('));
        var names=Regex.Matches(insertParams,@"\[([a-zA-Z0-9]+)\]");
     
        var remaining=names.Cast<Match>().Select(m=>m.Groups[1].Value).Where(m=>queryProperties.Select(qp=>qp.Name).Contains(m)).ToArray(); //scrape out items that the anonymous select doesn't include a name/value for
          
          //selectAliases[propertyPositions[10]]
          //remaining[10]
        var insertParamsOrdered = remaining.Select((s, i) => new { Position = propertyPositions[i], s })
           .OrderBy(o => o.Position).Select(x => x.s).ToArray();
       var insertParamsDelimited = insertParamsOrdered.Aggregate((s1, s2) => s1 + "," + s2);
       var commandText = target + "(" + insertParamsDelimited + ")" + sql;
       var result=this.ExecuteStoreCommand(commandText,queryParams.Select(qp=>new System.Data.SqlClient.SqlParameter{ ParameterName=qp.Name, Value=qp.Value}).ToArray());
       return result;
    }
