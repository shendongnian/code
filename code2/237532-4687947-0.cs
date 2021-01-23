    protected void Page_Load(object sender, EventArgs e)
    {
        // Do your API code here unless you want it to occur only the first
        // time the page loads, in which case put it in the IF statement below.
        if (!IsPostBack)
        {
            PopulateDropDown();
        }
    }
