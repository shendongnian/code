    //Form 1
    protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = globals.test;
            globals.test = "WorksGreat";
            Response.Redirect("Default2.aspx");
        }
    
    //form2
     protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = globals.test;
        }
