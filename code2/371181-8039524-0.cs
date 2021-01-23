    [WebMethod(EnableSession = true)]
    public static string ReadSearch(string nm_what, string nm_where, int pageindex)
    {
    }
    //from another page
    protected void Page_Load(object sender, EventArgs e)
    { 
        //example
        string s = Search.ReadSearch("this","here",2); //add namespace and references needed
    }
