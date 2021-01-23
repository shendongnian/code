    myConnection.Open();
    SqlCommand myCommand = new SqlCommand("Select * from myDT", myConnection);
    myCommand.Parameters.Add("user", user.Text);  
    SqlDataReader reader = myCommand.ExecuteReader();
    if(reader.HasRows)  // i remember there is such a thing !
    {
    
    }
    
    // myCommand.Parameters.Add("@user", user.Text); is false as i remember
