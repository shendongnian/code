    String fname = ""
    SqlCommand getFnameCommand = New SqlCommand("SELECT TOP 1 fname FROM profile ORDER BY fname DESC;", New SqlClient.SqlConnection"Your Connection String"))
    getFnameCommand.Connection.Open()
    fname = getFnameCommand.ExecuteScalar()
    getFnameCommand.Connection.Close()
    label1.text=fname;
