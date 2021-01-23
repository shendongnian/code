    public void Page_Load(object sender, EventArgs e)
    {
            string connectionString = ConfigurationManager.ConnectionStrings["nameyouwanttogivethisconnection"].ConnectionString;
            SqlConnection SqlConnection = new SqlConnection(connectionString);
            
    }
