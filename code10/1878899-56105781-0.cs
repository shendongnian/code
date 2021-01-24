    var _msgs = new List<string>();
    using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(<YourConnectionString>))
    {
        //Appending an event handler for InfoMessages
        con.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs args)
        {
            //reader will invoke the delegate on every itteration of results coming from query
            _msgs.Add(args.Message);
            return;
        };
        using (var cmd = new System.Data.SqlClient.SqlCommand("spTestMessage", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            using (System.Data.SqlClient.SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                var incr = 0;
                while (await reader.ReadAsync())
                {
                    //Statements to read data from Table1
                    Console.WriteLine(reader.GetString(0));
                    incr++;
                }
                while (await reader.NextResultAsync())
                {
                    while (await reader.ReadAsync())
                    {
                         //Statements to read data from Table2
                         Console.WriteLine(reader.GetString(0));
                         incr++;
                     }
                 }
             }
         } 
    }
