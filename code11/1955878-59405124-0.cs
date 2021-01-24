    private CancellationTokenSource cts;
    private async void TestSqlServerCancelSprocExecution()
    {
    cts = new CancellationTokenSource();
    try
    {
        await Task.Run(() =>
        {
            using (SqlConnection conn = new SqlConnection("connStr"))
            {
                conn.InfoMessage += conn_InfoMessage;
                conn.FireInfoMessageEventOnUserErrors = true;
                conn.Open();
                var cmd = conn.CreateCommand();
                cts.Token.Register(() => cmd.Cancel());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.[CancelSprocTest]";
                cmd.ExecuteNonQuery();
            }
       });
    }
    catch (SqlException)
    {
        // sproc was cancelled
    }
