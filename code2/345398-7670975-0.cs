        public string Query(string dynIndexName, string query)
        {
            using (var session = store.OpenSession())
            {
                var q = new IndexQuery();
                q.Query = query;
                var result = session.Advanced.DatabaseCommands.Query("dynamic/" + dynIndexName, q, new string[0]);
                return "[" + String.Join(",", result.Results.Select(r => r.ToString())) + "]";
            }
        }
