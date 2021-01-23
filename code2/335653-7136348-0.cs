    private Wait myCustomWaitDialog = new Wait(); // My Waiting form
    private void SaveToDatabase(myObjectToSave obj) // Method called to save data do DB
    {
        // Create the connections and queries
        (...)
        // This is what I did
        // Show Waiting Form
        myCustomWaitDialog.Show();
        // Instanciate the command that will carry the query and to DB
        SqlCommand command = new SqlCommand(Queries.GetData(code), conn);
        // This is important
        //Create event that will fire when the command completes
        command.StatementCompleted += new StatementCompletedEventHandler(command_StatementCompleted);
        // Execute the transaction
        SqlDataReader reader = command.ExecuteReader();
        // Rest of the code (validations, close connections, try/catch, etc
        (...)
    }
    void command_StatementCompleted(object sender, StatementCompletedEventArgs e)
    {
        // This is the method that closes my Waiting Dialog 
        myCustomWaitDialog.CloseDialog();
        myCustomWaitDialog.Dispose();
    }
