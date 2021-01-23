    public string appendCondition(String sqlQuery, String field, Object value)
    { 
     string resultQuery = sqlQuery + " " + value == null ? " IS NULL " : "=" + value.ToString();
     return resultQuery;
    }
