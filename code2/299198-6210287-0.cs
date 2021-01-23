    var attemptNumber = 0;
    while (true)
    {
        try
        {
            using (var connection = new SqlConnection())
            {
                connection.Open();
                        
                // do the job
            }
            break;
        }
        catch (SqlException exception)
        {
            // log exception
            attemptNumber++;
            if (attemptNumber > 3)
                throw; // let it crash
        }
    }
