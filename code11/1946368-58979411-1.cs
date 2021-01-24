    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // populate control with database value
            txtUsername.Text = objBO_MstrUsers.UserName;
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        // get data from control
        objBO_MstrUsers.UserName = txtUsername.Text;
    
        // do anything with the data, e.g. store in database
        // ...
    }
