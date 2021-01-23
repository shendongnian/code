    public object Scalar(string sql, params object[] args) {
        object result = null;
        using (var conn = OpenConnection()) {
            result = CreateCommand(sql, conn, args).ExecuteScalar();
        }
        return result;
    } 
