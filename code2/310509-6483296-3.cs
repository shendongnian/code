    string updateStmt = "UPDATE dbo.YourTable SET ordersTillNow = ordersTillNow + 1 " +
                        "WHERE CustomerID = @CustomerID";
    using(SqlConnection _conn = new SqlConnection("your-connection-string-here"))
    using(SqlCommand _cmd = new SqlCommand(_conn, updateStmt))
    {
       _cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = yourCustomerID;
       _conn.Open();
       _cmd.ExecuteNonQuery();
       _conn.Close();
    }
