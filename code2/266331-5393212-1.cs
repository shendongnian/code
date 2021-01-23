    var sb = new StringBuilder();
    var isFirst = true;
    foreach (var element in dic)
    {
    	if(!isFirst)
    		sb.Append(" AND ");
    	else
    		isFirst = false;
    	sb.Append(element.Key);
    	sb.Append(" = ");
        if(element.Value is decimal)
          sb.Append(CastToSqlDecimalString((decimal)element.Value));
        else
    	  sb.Append("'" + String.Format(CultureInfo.InvariantCulture, "{0:G}", element.Value).Replace("'", "''") + "'");
    }
