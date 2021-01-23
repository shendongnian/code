    string filename = "abc123.jpg";
    using( SqlConnection link = new SqlConnection(/*...*/;)) )
    {
        // sql statement with parameter
        string sqlcode = "INSERT INTO file_uploads (upload_filename) VALUES (@filename)";
        using( SqlCommand sql = new SqlCommand(sqlcode,link) )
        {
            // add filename parameter
            sql.Parameters.AddWithValue("filename", filename);
            link.open();
            sql.ExecuteNonQuery();
        }
    }
