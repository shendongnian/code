            var idList = new List<string> { "1", "2", "3" };
            string sql = "SELECT * FROM TableName WHERE Id IN (@id)";
            using (var connection = new SqlConnection(/* connection info */))
            {
                var command = new SqlCommand(sql, connection);
                var ids = string.Join(",", idList);
                // add your generated id string here
                command.Parameters.AddWithValue("@id", ids);
                command.ExecuteReader();
                    ....
            }
