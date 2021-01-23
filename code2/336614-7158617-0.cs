    private void GetData()
    {
        try
        {
            // Initialize the DataSet.
            dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
    
            // Create the connection string for the AdventureWorks sample database.
            string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;"
                + "Integrated Security=true;";
    
            // Create the command strings for querying the Contact table.
            string contactSelectCommand = "SELECT ContactID, Title, FirstName, LastName, EmailAddress, Phone FROM Person.Contact";
    
            // Create the contacts data adapter.
            contactsDataAdapter = new SqlDataAdapter(
                contactSelectCommand,
                connectionString);
    
            // Create a command builder to generate SQL update, insert, and
            // delete commands based on the contacts select command. These are used to
            // update the database.
            SqlCommandBuilder contactsCommandBuilder = new SqlCommandBuilder(contactsDataAdapter);
    
            // Fill the data set with the contact information.
            contactsDataAdapter.Fill(dataSet, "Contact");
    
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
