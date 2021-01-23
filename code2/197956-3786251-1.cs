    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            int id = 3; // get from querystring
            DataSet ds = getComputer(id);
            DataRow dr = ds.Tables[0].Rows[0]; // get the first row returned
    
            // populate form controls
            txtFirstName.Text = dr["FirstName"].ToString();
            ddlState.SelectedValue = dr["State"].ToString();
        }
    }
