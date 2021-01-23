     public static List<AllQuestionsPresented> GetAllThreads()
    {
        List<AllQuestionsPresented> allThreads = new List<AllQuestionsPresented>();
        string findUserID = "SELECT UserID FROM Users";
        string myConnectionString = AllQuestionsPresented.connectionString;
    
    using (SqlConnection myConnection = new SqlConnection(myConnectionString))
        {
            SqlCommand sqlCommand = new SqlCommand(findUserID, myConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                AllQuestionsPresented allQ = new AllQuestionsPresented((Guid)reader["UserID"]);
                allThreads.Add(allQ);
            }
        }
        return allThreads;
    }
