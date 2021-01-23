    using (var cn = new MySqlConnection("Server=localhost; Database=gymwebsite2; User=root; Password=commando;"))
    using (var cmd = cn.CreateCommand())
    {
        cn.Open();
        cmd.CommandText = "SELECT u.UserID, u.FirstName, u.SecondName, p.PicturePath FROM User u LEFT JOIN Pictures p ON p.UserID = u.UserID WHERE u.FirstName LIKE '@search' ORDER BY u.UserID DESC";
        cmd.Parameters.AddWithValue("@search", search);
        using (var reader = cmd.ExecuteReader())
        {
            test1.Controls.Clear();
            while (reader.Read())
            {
                ...
            }
        }
    }
