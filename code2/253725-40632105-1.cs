     public static class MyExtensions
        {
            public async static Task<string> toJSON(this SqlDataReader reader)
            {            
                var results = await reader.GetSerialized();
                return JsonConvert.SerializeObject(results, Formatting.Indented);
            }
            public async static Task<IEnumerable<Dictionary<string, object>>> GetSerialized(this SqlDataReader reader)
            {
                var results = new List<Dictionary<string, object>>();
                var cols = new List<string>();
                for (var i = 0; i < reader.FieldCount; i++)
                    cols.Add(reader.GetName(i));
    
                while (await reader.ReadAsync())
                    results.Add(SerializeRow(cols, reader));
    
                return results;
            }
            private static Dictionary<string, object> SerializeRow(IEnumerable<string> cols,
                                                            SqlDataReader reader)
            {
                var result = new Dictionary<string, object>();
                foreach (var col in cols)
                    result.Add(col, reader[col]);
                return result;
            }
        }
