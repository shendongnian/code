    [Visual Basic] 
    Public Sub ReadMyData(myConnString As String)
        Dim mySelectQuery As String = "SELECT OrderID, CustomerID FROM Orders"
        Dim myConnection As New SqlConnection(myConnString)
        Dim myCommand As New SqlCommand(mySelectQuery, myConnection)
        myConnection.Open()
        Dim myReader As SqlDataReader
        myReader = myCommand.ExecuteReader()
        ' Always call Read before accessing data.
        While myReader.Read()
            Console.WriteLine((myReader.GetInt32(0) & ", " & myReader.GetString(1)))
        End While
        ' always call Close when done reading.
        myReader.Close()
        ' Close the connection when done with it.
        myConnection.Close()
    End Sub 'ReadMyData
    
    [C#] 
    public void ReadMyData(string myConnString) {
        string mySelectQuery = "SELECT OrderID, CustomerID FROM Orders";
        SqlConnection myConnection = new SqlConnection(myConnString);
        SqlCommand myCommand = new SqlCommand(mySelectQuery,myConnection);
        myConnection.Open();
        SqlDataReader myReader;
        myReader = myCommand.ExecuteReader();
        // Always call Read before accessing data.
        while (myReader.Read()) {
           Console.WriteLine(myReader.GetInt32(0) + ", " + myReader.GetString(1));
        }
        // always call Close when done reading.
        myReader.Close();
        // Close the connection when done with it.
        myConnection.Close();
     }
