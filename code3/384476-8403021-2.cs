    string ConString = @"Provider=Microsoft.Jet.OLEDB.4.0;DataSource=
                                         C:\DatabaseNameGoesHere.mdb";
                OleDbConnection Con = new OleDbConnection(ConString);
                OleDbCommand Command = Con.CreateCommand();
     
                // create the DataSet
                DataSet ds = new DataSet();
     
                // clear the grids data source
                PlaceToPutTheData.DataSource = null;
     
                // open the connection
                Con.Open();
     
                // run the query
                Command.CommandText = "Select the data from the table you need;
                OleDbDataAdapter Adapter = new OleDbDataAdapter(Command);
                Adapter.Fill(ds);
     
                // close the connection
                Con.Close();
     
                // set the grid's data source
                PlaceToPutTheData.DataSource = ds.Tables[0];
