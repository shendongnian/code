      protected void Page_Load(object sender, EventArgs e)
      {
        if (!IsPostBack)
        {
         SqlConnection cn = new SqlConnection(GlobalData.connectionstring);
         string readnamesquery = "select cwFullTitle from tbCowWorkers";
         cn.Open();
         SqlCommand cmd = new SqlCommand(readnamesquery, cn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         da.Fill(dt);
         ddlUsers.DataSource = dt;
         ddlUsers.DataValueField = "cwFullTitle";
         ddlUsers.DataTextField = "cwFullTitle";
         ddlUsers.DataBind();
         cn.Close();
        }
      }
     
      protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
      {
         // insert selected value to database
        SqlConnection cn = new SqlConnection(GlobalData.connectionstring);
        string registerQuery = "insert into Depot (dTdeliveryName) values 
        (N'"+ddlUsers.SelectedValue.ToString()+"')";
        SqlCommand cmd = new SqlCommand(registerQuery, cn);
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
      }
       
