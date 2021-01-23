    private void Test()
    {
        string Query =
            @"INSERT INTO [Friends]
              (
              	[ParentUserID],
              	[ChildUserID]
              )
              VALUES
              (
              	@UserID,
              	@FriendID
              )";
        using ( SqlConnection oSqlConnection = new SqlConnection( "connect string" ) )
        {
            oSqlConnection.Open();
            using (SqlCommand oSqlCommand = new SqlCommand(Query,oSqlConnection))
            {
                oSqlCommand.Parameters.AddWithValue("@UserID", Session["UserID"]);
                oSqlCommand.Parameters.AddWithValue("@FriendID", Session["FriendID"]);
                oSqlCommand.ExecuteNonQuery();
            }
        }
    }
