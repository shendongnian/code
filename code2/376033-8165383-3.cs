    public void BindTheGridView()
        {
            SqlConnection conn = new SqlConnection(Connstring);
            string sql = "Select * from [UserDB]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            conn.Close();
            SqlDataSource1.DataSource = dtb;
            SqlDataSource1.DataBind();
        }
