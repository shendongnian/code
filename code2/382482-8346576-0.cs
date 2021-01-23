    int memberId = 0;
    using (var connection = new SqlConnection(conectionString))
    using (var command = new SqlCommand(StrSql, connection))
    {
        command.Parameters.Add("@GuidID", SqlDbType.Int).Value = guid;
        memberId = (int) command.ExecuteScalar();
    }
    return memberId;
