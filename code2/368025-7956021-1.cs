    public void Page_Load(object sender, EventArgs e)
    {
            string connectionString = ConfigurationManager.ConnectionStrings["nameyouwanttogivethisconnection"].ConnectionString;
            SqlConnection SqlConnection = new SqlConnection(connectionString);
            SqlCommand SqlCommand = new SqlCommand("update table etc etc....",SqlConnection);
            SqlConnection.Open();
            SqlCommand.ExecuteNonQuery(); //This line is for updates and inserts, use SqlCommand.ExecuteReader(CommandBehavior.CloseConnection); for select statments
            SqlConnection.Close();
    }
