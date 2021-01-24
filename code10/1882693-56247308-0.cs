    using (SqlConnection con = new SqlConnection("YOUR CONNECTION STRING"))
    {
        string query = "SELECT custNeed FROM Customers WHERE ID = 1000001;";
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            con.Open();
            //since you're only returning a single column you can forego the reader 
            //and just use ExecuteScalar
            checkBox1.Checked = (bool)cmd.ExecuteScalar();
        }
    }
