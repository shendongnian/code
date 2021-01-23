    using(SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=MailDB;Integrated Security=True"))
    using (SqlCommand comm = new SqlCommand("select Text,product from Source", conn))
    {
        conn.Open();
        using (SqlDataReader rd = comm.ExecuteReader())
        {
            //...
        }
    }
