        private IEnumerable<string> getData()
        {
            // Create comma delimited list of serials:
            int currentSerial = 4452; // your constant
            var serialsList = new List<int>();
            var count = 100;
            for (int i = 0; i < count; i++)
                serialsList.Add(currentSerial++);
            var connString = getConnectionString();
            var results = new List<string>();
            string sqlSelect = $"SELECT SerialNumber, OrderNumber FROM SerialNumbersMFG WHERE SerialNumber IN ({string.Join(",", serialsList)})";
            using (var connection = new SqlConnection(connString)) // BadgeDatabaseDB.GetConnection();
            {
                using (var command = new SqlCommand(sqlSelect, connection))
                {
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        results.Add(dataReader["OrderNumber"].ToString());
                }
            }
            return results;
        }
