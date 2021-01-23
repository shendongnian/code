    protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data source=(local);Database=northwind;Integrated security=true";
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Categories", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter mySqlAdapter = new SqlDataAdapter(cmd);
            DataSet myDataSet = new DataSet();
            mySqlAdapter.Fill(myDataSet);
            DataTable myDataTable = myDataSet.Tables[0];
            GridView1.DataSource = myDataTable;
        if(!IsPostBack)  /// <<<<<<<<<<<<<<<<<<<<<<
            GridView1.DataBind();
            Session["mytable"] = myDataTable;
        }
