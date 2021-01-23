    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            string ok = Request.Form["__OK"]; //getting data from hidden input
            if (ok == "1") // if it's 1 checking succeeded, thus it's ok to save data 
            insertTextBoxValueintoDBTable(TextBox1.Text); //saving data
        }
    }
