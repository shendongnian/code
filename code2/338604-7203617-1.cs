    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString; // Add your connection string here if you have it in your web.config file, if not, just type it out manually.
            string mySelectQuery = "SELECT client_url, client_name FROM Clients";
            SqlConnection myConnection = new SqlConnection(strConnection);
            SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
            myConnection.Open();
            SqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            myRepeater.DataSource = myReader;
            myRepeater.DataBind();
            myReader.Close();
            myConnection.Close();
        }
    }
