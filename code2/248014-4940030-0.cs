    public bool TryGetParticipationGrade(SqlConnection sqlConn, out int enrollmentID)
    {
        SqlCommand sqlCmd = new SqlCommand("dbo.usp_participation_byEnrollmentID_Select", sqlConn);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@enrollmentID", enrollmentID);
        sqlConn.Open();
        enrollmentId = (int)sqlCmd.ExecuteScalar();
        sqlConn.Close();
        return enrollmentId != -1;        
    }
