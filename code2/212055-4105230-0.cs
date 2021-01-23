    void SaveData(string projectName, DateTime biddingDueDate, string status, DateTime projectStartDate, string assignedTo, int pointsWorth, string staffCredits)
    {
    	try
    	{
    		string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Customers.mdf;Integrated Security=True;User Instance=True";
    		using (SqlConnection connection = new SqlConnection(connectionString))
    		using (SqlCommand command = connection.CreateCommand())
    		{
    			command.CommandText = "INSERT INTO ProjectList (ProjectName, BiddingDueDate, Status, ProjectStartDate, ProjectEndDate, AssignedTo, PointsWorth, StaffCredits) VALUES (@projectName, @biddingDueDate, @status, @projectStartDate, @projectStartDate, @assignedTo, @pointsWorth, @staffCredits)";
    
    			command.Parameters.AddWithValue("@projectName", projectName);
    			command.Parameters.AddWithValue("@biddingDueDate", biddingDueDate);
    			command.Parameters.AddWithValue("@status", status);
    			command.Parameters.AddWithValue("@projectStartDate", projectStartDate);
    			command.Parameters.AddWithValue("@assignedTo", assignedTo);
    			command.Parameters.AddWithValue("@pointsWorth", pointsWorth);
    			command.Parameters.AddWithValue("@staffCredits", staffCredits);
    
    			connection.Open();
    			command.ExecuteNonQuery();
    		}
    	}
    	catch (SqlException ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    
    }
