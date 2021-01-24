    string connString = @"Data Source=...";
    string queryLecturer = "select name_student from student";
    using (var conn = new SqlConnection(connString))
    using (var cmd = new SqlCommand(queryLecturer)) {
        conn.Open();
        using (SqlDataReader reader = cmd.ExecuteReader()) {
            var list = new List<string>();
            while (reader.Read()) {
                list.Add(reader.GetString(0)); // 0 is the column index.
            }
            DropDownListID.DataSource = list;
        }
    }
