    private Grammar CreateCustomGrammar()
    {
        DataTable myTable = new DataTable();
        using ( OleDbConnection myConnection = new OleDbConnection(connection) )
        using ( OleDbCommand myCommand = new OleDbCommand("Select * From wordtable", myConnection) )
        {
        myConnection.Open();
        myTable.Load (myCommand.ExecuteReader();
        grammerList.AddRange ((from r in myTable.Rows select r[0]..ToString()).ToArray());
        }
       Choices mychoices = new Choices(grammerList.ToArray());
       GrammarBuilder myGrammarBuilder = new GrammarBuilder(c);
       Grammar myGrammar = new Grammar(myGrammarBuilder);
       return myGrammar; 
    }
