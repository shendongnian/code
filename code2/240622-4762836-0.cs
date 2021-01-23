    public override ToolPart[] GetToolParts()
    {
    	ToolPart[] tps = new ToolPart[3];
    
    	WebPartToolPart wptp = new WebPartToolPart();
    	CustomPropertyToolPart cptp = new CustomPropertyToolPart();
    	tps(0) = cptp;
    	tps(1) = wptp;
    	tps(2) = new ListSelectionToolPart(SPContext.Current.Web, "List Settings");
    
    	return tps;
    }
    private string _TargetListGUID;
    [Personalizable(PersonalizationScope.Shared)]
    [WebBrowsable(false)]
    [WebDisplayName("Target List GUID")]
    [WebDescription("GUID of the Target List")]
    [SPWebCategoryName("Internal")]
    public string TargetListGUID {
	  get { return _TargetListGUID; }
	  set { _TargetListGUID = value; }
    }
