    void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
       {
           button1.Text = "Processing " + variable + " Records"; 
           button1.CommandArgument = variable;
       }
    }
