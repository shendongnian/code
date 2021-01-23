    String fname = ""
    // Create a new SqlCommand with your query to get the proper name and the connection string
    SqlCommand getFnameCommand = New SqlCommand("SELECT TOP 1 fname FROM profile ORDER BY fname DESC;", New SqlClient.SqlConnection"Your Connection String"))
    getFnameCommand.Connection.Open() // Open the SqlConnection
    fname = getFnameCommand.ExecuteScalar() // This pulls the result from the first column of the first row of your query result
    getFnameCommand.Connection.Close() //Close the SqlConnection
    label1.text=fname; //Set your label text to the data you just pulled
