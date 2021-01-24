    SqlDataReader datareader = Class.Month(comboBox2.SelectedItem.ToString());
    
    try
    {
        if (datareader.Read()) // It will only checks the value if row returned
        {
           int Money= dr.GetInt32(0); 
        }
        else
        {
           // No data in datareader
        }
    }
    catch (Exception exc) //If any run-time error occurs it would be handled
    {
        // exc.Message // contains the error message if error happens
    }
