            using (var connection = new SqlConnection(_connectionString))
            {
                regularRecords = connection.Query<RegularRecord>(
                        QueryRetriever.GetQuery("GetRegularRecords.sql"),
                        dynamicParameters
                    )
                    .ToList();
            }
