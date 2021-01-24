    SqlDataReader datareader = Class.Month(comboBox2.SelectedItem.ToString());
    
    if (datareader.Read()) // It will only checks the value if row returned
    {
       int Money= dr.GetInt32(0); 
    }
    else
    {
       // No data in datareader
    }
