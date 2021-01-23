    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    myVariable = "abc";
                }
    else
    {
    // hey im a postback, i need a value though!
    myVariable = "xyz";
    }
            }
