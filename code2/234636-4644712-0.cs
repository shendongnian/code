    public static string DoQuotes(string sql)
        {
            if (sql == null)
                return "";
            else
                return sql.Replace("'", "''");
        }
