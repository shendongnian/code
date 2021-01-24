     List<kurvliste> kurv_1 = new List<kurvliste>();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<kurvliste> kurv_2 = (List<kurvliste>)Session["kurv"];
        if (kurv_2 == null)
        {
            kurv_2 = new List<kurvliste>();
            Session["kurv"] = kurv_2; // Store the new list in the session object!
        }    
    }
    
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        kurv_1.Add(new kurvliste(1,1,1, "Produktnavn"));
        Session["kurv"] = kurv_1;
    }
