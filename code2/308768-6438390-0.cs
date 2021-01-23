    const string cRemStateNameConst = "cRemState_cnst";
    
    public int cRemState
    {
    	set
    	{
    		if (value == -1)
    			ViewState.Remove(cRemStateNameConst);
    		else
    			ViewState[cRemStateNameConst] = value;
    	}
    	get
    	{
    		if (ViewState[cRemStateNameConst] is int)
    			return (int)ViewState[cRemStateNameConst];
    		else
    			return -1;
    	}
    }
    
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
    	if(cRemState == 1)
    		GetTheData();
    }
    
    protected void Button1_Click1(object sender, EventArgs e)
    {
    	cRemState = 1;
    	GetTheData();
        dataGrid.DataBind();
    }
    
    void GetTheData()
    {
        string t = @"<countries>
                <country>
                <name>ANGOLA</name><code>1</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>2</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>3</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>4</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>5</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>6</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>24</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>24</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>24</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>24</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>24</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>24</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>24</code><size>1345 amp</size>
                </country>
                <country>
                <name>ANGOLA</name><code>24</code><size>1345 amp</size>
                </country>
    
                <country>
                <name>BENIN</name><code>204</code><size>435 amp</size>
                </country>
                </countries>";
        //string bgtFocusCmd = "<bgfocuscmd >";
        //string countCmd = "<count name='" + Session["operation"] + "'customerid='" + customerid.Text + "' breakup='" + breakup + "' date='" + DateFrom.Text + "' >";
        //bgtFocusCmd += countCmd + "</bgfocuscmd>";
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(t);
        DataSet resultData = new DataSet();
        resultData.ReadXml(new StringReader(doc.OuterXml));
        dataGrid.DataSource = resultData.Tables[0].DefaultView;
        
    }
