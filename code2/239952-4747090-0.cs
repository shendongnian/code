    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             if (!String.IsNullOrEmpty(this.Request.QueryString[{VariableName]))
             {
                  string someVariable = this.Request.QueryString[{VariableName}];
             }
        }
    }
