    using (SqlConnection conn = new SqlConnection(CSs))
        {
            string query = "Your SQL Query here";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "sometablename");
            firstnametext.Text = Convert.ToString(ds.Tables["sometablename"].Rows[0]["Firstname"]);
        }
