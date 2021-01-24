    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();
        }
    }
    
    private void GetData()
    {
        SqlDataReader dr;
        using (SqlConnection con = new SqlConnection([YOUR CONNECTION STRING]))
        {
            con.Open();
            // replace with your query
            using (SqlCommand cmd = new SqlCommand($"SELECT Name,Email,Address FROM Customers WHERE ID={Request["id"]}", con))
            {
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read())
                {
                    Name.Text = dr["Name"].ToString();
                    Address.Text = dr["Address"].ToString();
                    Email.Text = dr["Email"].ToString();
                    // etc
                }
            }
        }
    }
