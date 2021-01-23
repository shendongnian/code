    using (SqlConnection conn = GetSQLConnection())
    {
        using (SqlCommand cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = @"SELECT id FROM widgets INNER JOIN widget_nums on .... WHERE id = @WidgetID;";
            cmd.Parameters.AddWithValue("WidgetID", WidgetID);
            using (SqlDataReader Reader = cmd.ExecuteReader()) {
               return MapReaderToWidget(reader).FirstOrDefault();
            }
        }
    }
