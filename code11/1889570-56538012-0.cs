    ClientContext ctx = new ClientContext("http://sp2013");
    ctx.Credentials = new NetworkCredential("username", "password", "domain");
    CamlQuery camlQuery = new CamlQuery();
    List list = ctx.Web.Lists.GetByTitle("Tasks");
    ListItemCollection listItems = list.GetItems(camlQuery);
    ctx.Load(listItems);
    ctx.ExecuteQuery();
    
    foreach (var listItem in listItems)
    {
    	string status = "";
    	string mStatus = listItem["_ModerationStatus"].ToString();
    	if (mStatus == "0")
    	{
    		status = "Approved";
    	}
    	else if (mStatus == "1")
    	{
    		status = "Denied";
    	}
    	else if (mStatus == "2")
    	{
    		status = "Pending";
    	}
    	else if (mStatus == "3")
    	{
    		status = "Draft";
    	}
    	else if (mStatus == "4")
    	{
    		status = "Scheduled";
    	}
    	Console.WriteLine("Title: " + listItem["Title"] + " Approval Status:" + status);
    }
