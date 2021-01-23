    protected void Page_Load(object sender, EventArgs e)
    {
     If(!IsPostBack)
     {
        string x = Request.QueryString["SubId"];
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string displayQuery = "SELECT CustName, CustAdd, CustCity, CustState, CustZip FROM Customer WHERE SubId =" + x;
        string broQuery = "SELECT EntityType FROM Broker WHERE SubId =" + x;
        string ddlQuery = "SELECT ProductId FROM SubmissionProducts WHERE SubmissionId =" + x;
        using (SqlConnection displayConn = new SqlConnection(connectionString))
        {
            displayConn.Open();
            SqlCommand DlistCmd = new SqlCommand(ddlQuery, displayConn);
            using (SqlDataReader Ddldr = DlistCmd.ExecuteReader())
            {
                while (Ddldr.Read())
                {
                    switch (Ddldr.GetInt32(0))
                    {
                        case 1:
                            DdlProductList.Items.RemoveAt(1);
                            break;
                        case 2:
                            DdlProductList.Items.RemoveAt(2);
                            break;
                        case 3:
                            DdlProductList.Items.RemoveAt(3);
                            break;
                        case 4:
                            DdlProductList.Items.RemoveAt(4);
                            break;
                        case 5:
                            DdlProductList.Items.RemoveAt(5);
                            break;
                        case 6:
                            DdlProductList.Items.RemoveAt(6);
                            break;
                        case 7:
                            DdlProductList.Items.RemoveAt(7);
                            break;
                        default:
                            break;
                    }
                }
            }
