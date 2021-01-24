`C#
.
.
.
OracleConnection test = new OracleConnection();
.
.
.
        using (OracleConnection test = new OracleConnection("Data Source=; User ID=; Password=")) // <-- SQLconnection here
        {
            test.Open(); // <-- Only Open connection
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
.
.
.
            }
         }
`
