    public static List<T> ExecuteStoredProcedure<T>(this ObjectContext dbContext, string storedProcedureName, params SqlParameter[] parameters)
    {
        var spSignature = new StringBuilder();
        object[] spParameters;
        bool hasTableVariables = parameters.Any(p => p.SqlDbType == SqlDbType.Structured);
        
        spSignature.AppendFormat("EXECUTE {0}", storedProcedureName);
        var length = parameters.Count() - 1;
        
        if (hasTableVariables)
        {
            var tableValueParameters = new List<SqlParameter>();
        
            for (int i = 0; i < parameters.Count(); i++)
            {
                switch (parameters[i].SqlDbType)
                {
                    case SqlDbType.Structured:
                        spSignature.AppendFormat(" @{0}", parameters[i].ParameterName);
                        tableValueParameters.Add(parameters[i]);
                        break;
                    case SqlDbType.VarChar:
                    case SqlDbType.Char:
                    case SqlDbType.Text:
                    case SqlDbType.NVarChar:
                    case SqlDbType.NChar:
                    case SqlDbType.NText:
                    case SqlDbType.Xml:
                    case SqlDbType.UniqueIdentifier:
                    case SqlDbType.Time:
                    case SqlDbType.Date:
                    case SqlDbType.DateTime:
                    case SqlDbType.DateTime2:
                    case SqlDbType.DateTimeOffset:
                    case SqlDbType.SmallDateTime:
                        // TODO: some magic here to avoid SQL injections
                        spSignature.AppendFormat(" '{0}'", parameters[i].Value.ToString());
                        break;
                    default:
                        spSignature.AppendFormat(" {0}", parameters[i].Value.ToString());
                        break;
                }
                            
                if (i != length) spSignature.Append(",");
            }
            spParameters = tableValueParameters.Cast<object>().ToArray();
        }
        else
        {
            for (int i = 0; i < parameters.Count(); i++)
            {
                spSignature.AppendFormat(" @{0}", parameters[i].ParameterName);
                if (i != length) spSignature.Append(",");
            }
            spParameters = parameters.Cast<object>().ToArray();
        }
        
        var query = dbContext.ExecuteStoreQuery<T>(spSignature.ToString(), spParameters);
        
        
        var list = query.ToList();
        return list;
    }
