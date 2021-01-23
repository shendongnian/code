        public static void Main() 
        {
           //...connecting to access db and getting data to datatable...
           // ...
           // Adding a new row to datatable.
           DataRow newRow = catDS.Tables["Categories"].NewRow();
           newRow["CategoryName"] = "New Category";
           catDS.Tables["Categories"].Rows.Add(newRow);
                
           // Include an event to fill in the Autonumber value.
           catDA.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);
            
        }
                
        protected static void OnRowUpdated(object sender, OleDbRowUpdatedEventArgs args)
        {
           // Include a variable and a command to retrieve the identity value from the Access database.
           int newID = 0;
           OleDbCommand idCMD = new OleDbCommand("SELECT @@IDENTITY", nwindConn);
                    
           if (args.StatementType == StatementType.Insert)
           {
              // Retrieve the identity value and store it in the CategoryID column.
              newID = (int)idCMD.ExecuteScalar();
              args.Row["CategoryID"] = newID;
           }
        }
