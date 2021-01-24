     SqlCommand cmd = new SqlCommand("Select Enddate from moudetails", con);
        SqlDataAdapter DA = new SqlDataAdapter(cmd);
        DataTable Dt = new DataTable();
        DA.Fill(Dt);
        if (Dt.Rows.Count > 0)
        {
            string dateString = Dt.Rows[0]["Enddate"].ToString();
            //lbltest.Text = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy");
            //Label1.Text = Dt.Rows[0]["Enddate"].ToString();
            Label1.Text = DateTime.Parse(dateString).AddDays(-3).ToString();
        }
