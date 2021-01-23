    protected void Page_Load(object sender, EventArgs e)
    {
        string cuisinesSelectStatement = "SELECT Cuisines.CuisineId, Cuisines.CuisineType FROM Cuisines";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString);
        SqlCommand comm = new SqlCommand(cuisinesSelectStatement , conn);
        SqlDataReader reader1;
        chkbxlstCuisines.DataValueField = "CuisineId";
        chkbxlstCuisines.DataTextField = "CuisineType";
        conn.Open();
        reader1 = comm.ExecuteReader();
        chkbxlstCuisines.DataSource = reader1;
        chkbxlstCuisines.DataBind();
        
            //conn.Close();
    }
