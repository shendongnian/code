    try
    {
        ....
        using(OleDbConnection connection = new OleDbConnection(......))
        {
             connection.Open();
             ....
             string cmdText = "yourdetailquery";
             using(OleDbCommand cmdDetail = new OleDbCommand(cmdText, connection))
             {
                 .... // parameters
                 using(OleDbDataReader rdDetail = cmdDetail.ExecuteReader())
                 {
                   ... read detail data .... 
                 }
             }
             // here the rdDetail is closed and disposed, 
             // you can start a new reader without closing the connection
             cmdText = "yourcodequery";
             using(OleDbCommand cmdCode = new OleDbCommand(cmdText, connection))
             {
                 .... parameters
                 using(OleDbReader rdCode = cmdCode.ExecuteReader())
                 {
                     // read code data...
                 }
             }
             ... other command+reader
       }
       // Here the connection is closed and disposed
    }
    catch(Exception ex)
    {
        // any error goes here with the connection closed
    }
