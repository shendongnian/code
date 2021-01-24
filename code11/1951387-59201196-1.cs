public static void UpdateMethod(long id, int status, string date, SqlConnection connection, SqlTransaction transactionSql)
{
    var query = $"UPDATE table SET Status = @status, Date = @date WHERE Id = @id";
    var commandUpdate = new SqlCommand(query, connection, transactionSql);
    if (DateTime.TryParseExact(date, new string[] { "yyyy-MM-dd HH:mm:ss" }, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out DateTime datetime))
        commandUpdate.Parameters.Add(new SqlParameter("@date", datetime));
    else
        commandUpdate.Parameters.Add(new SqlParameter("@date", DBNull.Value));
    commandUpdate.Parameters.Add(new SqlParameter("@status", status));
    commandUpdate.Parameters.Add(new SqlParameter("@id", id));
    commandUpdate.Parameters.Add(new SqlParameter("@date", Convert.ToDateTime(date)));
    commandUpdate.ExecuteNonQuery();
}
