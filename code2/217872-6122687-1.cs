    protected void Page_Load(object sender, EventArgs e)
        {
            string strconnection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(strconnection);
            con.Open();
    
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ename,ecompany from example";
    
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
    
            DataSet ds = new DataSet();
            adp.Fill(ds, "example");
    
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "ename";
            DropDownList1.DataValueField = "ecompany";
            DropDownList1.DataBind();
        }
