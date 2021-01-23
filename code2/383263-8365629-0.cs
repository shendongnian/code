    public int GetMemberID(string guid)
    {
        string strConectionString = ConfigurationManager.AppSettings["DataBaseConnection"];
        string StrSql = "SELECT MemberID FROM MEMBERS WHERE (Guid = @GuidID)";
        int memberId;
        using (var connection = new SqlConnection(strConectionString))
        {
            connection.Open();
            using (var command = new SqlCommand(StrSql, connection))
            {
                command.Parameters.Add("@GuidID", SqlDbType.VarChar).Value = guid; 
                memberId = (int)command.ExecuteScalar();
            }
        }
        //returns 0 when it should be member id number
        return memberId; 
    }
