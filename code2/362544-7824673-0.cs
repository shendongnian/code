     // List for holding loaded houses
            static List<house> houses = new List<house>();
    
            // Variable to hold "command" which is the query to be executed
            private static OleDbCommand query;
    
            // Variable to hold the data reader to manipulate data from the database
            static OleDbDataReader dataReader;
    
            static void Main(string[] args)
            {
                // Get the houses in a list
                List<house> c = getHousesFromDb();
