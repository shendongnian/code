    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack){
             TextBox1.Text = Request.Form["Text1"].ToString();
        }
    
    }
