    DataTable dt = new DataTable();
    using (SqlCommand selectTags = new SqlCommand("select tag from Categories", cs))
    {
        cs.Open();
        using (SqlDataAdapter da = new SqlDataAdapter(selectTags))
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
        cs.Close();
    }
    list1.ItemsSource = dt.DefaultView;
