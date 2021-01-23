    public static int? getParticipationGrade(SqlConnection sqlConn, int enrollmentID)
    {
    	SqlCommand sqlCmd = new SqlCommand("dbo.usp_participation_byEnrollmentID_Select", sqlConn); 
    	sqlCmd.CommandType = CommandType.StoredProcedure; sqlCmd.Parameters.AddWithValue("@enrollmentID", enrollmentID); 
    	int ret = 0; 
    	sqlConn.Open(); 
    	ret = (int)sqlCmd.ExecuteScalar(); 
    	sqlConn.Close(); 
    	return ret < 0 ? (int?) null : ret;
    } 
