    private static bool createRecord(String table, IDictionary<String,String> data, System.Data.IDbConnection conn, OdbcTransaction trans) {
        [... some other code ...]
        int returnValue = 0;
        try {
            command.CommandText = sb.ToString();
            returnValue = command.ExecuteNonQuery();
            return returnValue == 1; // You return here in case no exception is thrown
        } finally {
            command.Dispose(); //You don't have a catch so the exception is passed on if thrown
        }
        return false; // This is never executed because there was either one of the above two exit points of the method reached.
    }
