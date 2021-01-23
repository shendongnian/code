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
        parameters.Add(new SqlParameter(parameterName, members[i]));
    }
    inClause.Append(")");
    // Now use inClause in the SQL, and parameters in the command parameters
