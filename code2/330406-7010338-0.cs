    String getConflictTimeInBetween = string.Format("select question_id,question_text from {0}  where start_time<=@start and end_time>=@end", data_variables.RES_TXT_STRING_QUESTION_TABLE);
    using (com = new SqlCommand(getConflictTimeInBetween, myConnection))
    {
    	com.Parameters.AddWithValue("@start", Convert.ToDateTime(start_full));
    	com.Parameters.AddWithValue("@end", Convert.ToDateTime(end_full));
    	using (dr = com.ExecuteReader())
    	{
    		if (dr.HasRows)
    		{
    			while (dr.Read())
    			{
    				//Assign to your textbox here   
    				conflictQuestionIdAtBetween = dr["question_id"].ToString();
    				conflictQuestionTextAtBetween=dr["question_text"].ToString();
    			}
    		}
    	}
    }
