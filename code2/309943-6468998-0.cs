    using (var db = new SqlConnection(connStr)) {
        using (var rs = new SqlCommand(someQuery, db).ExecuteReader()) {
            while (rs.Read()) {
                // do interesting things!
            }
        }
    }
