    using (SqlConnection conn = ...)
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT Picture FROM <tableName> WHERE ...", conn)
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                byte[] picData= reader["Picture"] as byte[] ?? null;
                if (picData!= null)
                {
                    using (MemoryStream ms = new MemoryStream(picData))
                    {
                        // Load the image from the memory stream. How you do it depends
                        // on whether you're using Windows Forms or WPF.
                        // For Windows Forms you could write:
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);
                    }
                }
            }
        }
    }
