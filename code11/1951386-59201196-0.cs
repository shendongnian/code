public static void UpdateMethod(long id, int status, string date, SqlConnection connection, SqlTransaction transactionSql)
{
  var query = $"UPDATE table SET Status = @status, Date = @date WHERE Id = @id";
  var commandUpdate = new SqlCommand(query, connection, transactionSql);
  commandUpdate.Parameters.Add(new SqlParameter("@status", status));
  commandUpdate.Parameters.Add(new SqlParameter("@id", id));
  commandUpdate.Parameters.Add(new SqlParameter("@date", Convert.ToDateTime(date)));
  commandUpdate.ExecuteNonQuery();
}
