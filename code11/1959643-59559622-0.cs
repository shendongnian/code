    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand =
                 new SqlCommand("insert into Persons values (@surName, @lastName, @dateOfBirth, @dateOfDeath, @gender, @father, @mother);", sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@surName", person.SurName);
                sqlCommand.Parameters.AddWithValue("@lastName", person.LastName);
                sqlCommand.Parameters.AddWithValue("@dateOfBirth", person.DateOfBirth);
                sqlCommand.Parameters.AddWithValue("@dateOfDeath", person.DateOfDeath);
                sqlCommand.Parameters.AddWithValue("@gender", person.gender);
                sqlCommand.Parameters.AddWithValue("@father", person.Father);
                sqlCommand.Parameters.AddWithValue("@mother", person.Mother);
    
               
    
                sqlCommand.ExecuteNonQuery();
            }
        }
