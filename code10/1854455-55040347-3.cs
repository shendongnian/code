    // using this const you avoid bugs in mispelling the correct key.
    const string ckurvlisteNameConst = "kurvliste_cnst";
    
    public List<kurvliste> kurv
    {
        get
        {
            // If not on the Session then add it
            if (Session[ckurvlisteNameConst] == null)                
                Session[ckurvlisteNameConst] = new List<kurvliste>();
    
            // this code is not exist on release, but I check to be sure that I did not 
            //  overwrite this Session with a different object.
            Debug.Assert(Session[ckurvlisteNameConst] is List<kurvliste>);
    
            return (List<kurvliste>)Session[ckurvlisteNameConst];
        }
    }
    
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        kurv.Add(new kurvliste(1,1,1, "Produktnavn"));
    }
