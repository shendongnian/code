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
            using(SqlCommand cmd = new SqlCommand("SELECT ID,Name,Email,Address FROM Customers", con))
            {
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                GridView1.DataSource = dr;
                GridView1.DataBind();
            }
        }           
    }
