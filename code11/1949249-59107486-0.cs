    Random rnd = new Random();
    long firstLRN;
    long addLRN;
    string FinalLRN;
    try
    {
        // Set connection
        connection.Open();
        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        
        // Generate the first random number
        firstLRN = rnd.Next(1000000000);
        addLRN = 100000000000 + firstLRN;
        FinalLRN = Convert.ToString(addLRN);
        // Query and if exists query with number++
        do {
            command.CommandText = "select LRN FROM Student_LRN where LRN = '" + FinalLRN + "'";
            // Execute the query and check if the number exists
            OleDbDataReader reader = command.ExecuteReader();
            // If number exists add 1 to the number
            if (reader.Read()){
                addLRN++;
                FinalLRN = Convert.ToString(addLRN);
            }
            else {
                break;
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error" + ex);
    }
    finally
    {
        connection.Close();
    }
