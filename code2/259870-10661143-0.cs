    public List<int[]> CreateSymbolByName(string SymbolName, bool AcceptDuplicates)
    {
        if (! AcceptDuplicates)  // check if "AcceptDuplicates" flag is set
        {
            List<int[]> ExistentSymbols = GetSymbolsByName(SymbolName, 0, 10); // create a list of int arrays with existent records
            if (ExistentSymbols.Count > 0) return ExistentSymbols; //(1) return existent records because creation of duplicates is not allowed
        }
        List<int[]> ResultedSymbols = new List<int[]>();  // prepare a empty list
        int[] symbolPosition = { 0, 0, 0, 0 }; // prepare a neutral position for the new symbol
        try // If SQL will fail, the code will continue with catch statement
        {
            //DEFAULT und NULL sind nicht als explizite Identitätswerte zulässig
            string commandString = "INSERT INTO [simbs] ([En]) OUTPUT INSERTED.ID VALUES ('" + SymbolName + "') "; // Insert in table "simbs" on column "En" the value stored by variable "SymbolName"
            SqlCommand mySqlCommand = new SqlCommand(commandString, SqlServerConnection); // initialize the query environment
            int LastInsertedId = (int)mySqlCommand.ExecuteNonQuery(); //(2) lunch the query and retrieve last inserted id
            if (SqlTrace) SQLView.Log(mySqlCommand.CommandText); // Log the text of the command
            if (LastInsertedId > 0) // if insertion of the new row in the table was successful
            {
                string commandString2 = "UPDATE [simbs] SET [IR] = [ID] WHERE [ID] = " + LastInsertedId + " ;"; // update the table by giving to another row the value of the last inserted id
                SqlCommand mySqlCommand2 = new SqlCommand(commandString2, SqlServerConnection); 
                mySqlCommand2.ExecuteNonQuery();
                symbolPosition[0] = LastInsertedId; // mark the position of the new inserted symbol
                ResultedSymbols.Add(symbolPosition); // add the new record to the results collection
            }
        }
        catch (SqlException retrieveSymbolIndexException) // this is executed only if there were errors in the try block
        {
            Console.WriteLine("Error: {0}", retrieveSymbolIndexException.ToString()); // user is informed about the error
        }
        CreateSymbolTable(LastInsertedId); //(3) // Create new table based on the last inserted id
        if (MyResultsTrace) SQLView.LogResult(LastInsertedId); // log the action
        return ResultedSymbols; // return the list containing this new record
    }
