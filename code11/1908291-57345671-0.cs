 protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
     //Loading Dropdown by calling This.
     LoadDdl();
    }
  }
//Load Dropdown From Database.
protected void LoadDdl(){
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
//Inserting Item to another table by selected index change.
  protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
  {
//Checking If it's not the default value.
   if(ddlUser.SelectedIndex != -1){
  // insert selected value to database
    SqlConnection cn = new SqlConnection(GlobalData.connectionstring);
    string registerQuery = "insert into Depot (dTdeliveryName) values 
    (N'"+ddlUsers.SelectedValue.ToString()+"')";
    SqlCommand cmd = new SqlCommand(registerQuery, cn);
    cn.Open();
    cmd.ExecuteNonQuery();
    cn.Close();
    }
  }
