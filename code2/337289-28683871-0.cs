        public static string InsertQuery(string into, NameValueCollection values)
        {
            var query = SQL
                .INSERT_INTO(into + " (" +
                             String.Join(" ,", values.Keys.Cast<String>().ToArray()) + 
                             ")")
                .VALUES(values.Keys.Cast<String>().Select(key => values[key]));
            return query.ToString();
        }
