    protected void Page_Load(object sender, EventArgs e)
    {
        // on this line, just remove the declaration
        // List<kurvliste> kurv = (List<kurvliste>)Session["kurv"];
        // do it like
        kurv = Session["kurv"] as List<kurvliste>;
        if (kurv == null)
        {
            kurv = new List<kurvliste>();
            Session["kurv"] = kurv; // Store the new list in the session object!
        }
    }
