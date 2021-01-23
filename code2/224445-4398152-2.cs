        StringBuilder sb = new StringBuilder();
        using(var conn = new SqlConnection(connectionString))
        using (var cmd = conn.CreateCommand()) {
            cmd.CommandText = @"
                SELECT TABLE_NAME
                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'
                AND TABLE_NAME <> 'dtProperties'
                ORDER BY TABLE_NAME";
            conn.Open();
            
            using (var reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    sb.AppendLine(reader.GetString(0));
                }
            }
        }
        string s = sb.ToString();
