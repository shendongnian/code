    string SQL = "SELECT * FROM Email ";
        string myConnString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + textBox1.Text;
        OleDbConnection myConnection = new OleDbConnection(myConnString);
        OleDbCommand myCommand = new OleDbCommand(SQL, myConnection);
        myConnection.Open();
        OleDbDataReader myReader = myCommand.ExecuteReader();
        while(myReader.Read())
        {
            View.Items.Add(myReader["NameOfColumnGoesHere"]);
        }
        myConnection.Close();
