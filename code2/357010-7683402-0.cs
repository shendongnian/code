    protected void Page_Load(object sender, EventArgs e)
    {
        if(!this.IsPostBack){
             string selectQuery = "SELECT * FROM [Month1$B2:D5]";
             OleDbConnection conn = new OleDbConnection(connString);
             conn.Open();
             OleDbDataAdapter da = new OleDbDataAdapter(selectQuery, conn);
             DataSet ds = new DataSet();
             da.Fill(ds);
             GridView1.DataSource = ds;
             GridView1.DataBind();
             conn.Close();
             da.Dispose();
             conn.Dispose();
        }
    }
