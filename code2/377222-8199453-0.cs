       public int GetTotalNoVotes()
        {
            //get database connection string from config file
            string strConectionString o= ConfigurationManager.AppSettings["DataBaseConnection"];
    
            SqlConnection conn = new SqlConnection(strConnectionString);
            conn.Open();
    
            SqlCommand oCommand = new SqlCommand("SELECT COUNT(1) AS Expr1 FROM Ratings WHERE (PicRating = 2) AND (PicID = 2)", conn);
    
            object oValue = oCommand.ExecuteScalar();
    
            conn.Close();
    
            if (oValue == DBNull.Value) {
               return 0;
            } else {
              return Convert.ToInt32(oValue);
            }
       }
