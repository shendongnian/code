    // Or create the command earlier, of course
    List<SqlParameter> parameters = new List<SqlParameter>();
    StringBuilder inClause = new StringBuilder("(");
    for (int i = 0; i < members.Count; i++)
    {
        string parameterName = "@p" + i;
        inClause.Append(parameterName);
        if (i != members.Count - 1)
        {
            inClause.Append(", ");
        }
        // Adjust data type as per schema
        SqlParameter parameter = new SqlParameter(parameterName, SqlDbType.NVarChar);
        parameter.Value = members[i];
        parameters.Add(parameter);
    }
    inClause.Append(")");
    // Now use inClause in the SQL, and parameters in the command parameters
