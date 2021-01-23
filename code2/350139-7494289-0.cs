    ArrayList Course = new ArrayList();
    const string query = "SELECT DISTINCT COUNT(Grouping) from Attendance";
    const string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=PSeminar;Integrated Security=true;Trusted_Connection=Yes;MultipleActiveResultSets=true";
    using (SqlConnection cn = new SqlConnection(connectionString))
    {
        using (SqlCommand cm = new SqlCommand(query, cn))
        {
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                Course.Add(reader.GetString(0));
            }
        }
    }
    //Course.ToArray(); // <-- cast to string array object do use in the pie chart
