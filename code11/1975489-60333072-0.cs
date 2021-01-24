     public class DataConn
        {
            string MyConString = "Driver={MySQL ODBC 5.3 Unicode Driver};" +
                      "SERVER=localhost;" +
                      "DATABASE=Bee;" +
                      "UID=root;" +
                      "PASSWORD=123;" +
                      "OPTION=4"; //  ODBC connection
            string Query = "SELECT * from member"; // Write Query
    
            using (OdbcConnection c = new OdbcConnection(myConString)) //New Connection
            {
                OdbcCommand cmd = new OdbcCommand(Query, c); 
                c.Open(); // Connection Open
                OdbcDataReader dr = cmd.ExecuteReader();
                // dr will get all data u want
                // Query better use "SELECT column[0], column[1] FROM `member`";
                // dr.GetString(0); -> for column[0]
                // dr.GetString(1); -> for column[1]
                // do something...
            }
        }
