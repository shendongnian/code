    var lst = new List<string>();
    lst.Add("Delete");
    lst.Add("Reports");
    lst.Add("Customer");
    
    Dictionary<int, string> d = new Dictionary<int, string>();
    d.Add(1, "Delete");
    d.Add(2, "Reports");
    
    var hyperlinkMap = new Dictionary<string, string>()
    {
    	{ "Delete", "Delete.aspx"},
    	{ "Reports", "Reports.aspx"}
    };
    
    foreach (var i in lst)
    {
    	if(d.ContainsValue(i))
    	{
    		HyperLink1.NavigateUrl = hyperlinkMap[i];
    	}
    	else
    	{
    		HyperLink2.Attributes["OnClick"] = "alert('Not a Valid User to Perform this operation'); return false";
    	}
    }
