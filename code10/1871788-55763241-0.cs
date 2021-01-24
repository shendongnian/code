        public async Task SomeAsyncMethod()
        {
            using (var connection = new SqlConnection("YOUR CONNECTION STRING"))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "YOUR QUERY";
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        // read from reader 
                    }
                }
            }
        }
