    using (OleDbConnection connection = new OleDbConnection(sConStr))
        {
            connection.Open();
            /// get sheet name
           dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
           //var sheets = dt.Rows[0].Field<string>("TABLE_NAME");
           // foreach(var sheet in sheets) //loop through the collection of sheets ;)
           // {
           var sheets = dt.Rows[0].Field<string>("TABLE_NAME");
                //your logic here...
                        string myexceldataquery = string.Format("Select * FROM [{0}]; ", sheets);
                        //get data
