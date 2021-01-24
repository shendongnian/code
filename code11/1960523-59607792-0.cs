    public static int subSiteCount = 0;
    public static int groupCount = 0;
    public static int listCount = 0;
    
    static void  Main(string[] args)
    {
    	string siteUrl = "https://tenant.sharepoint.com/sites/team";
    	string userName = "test@tenant.onmicrosoft.com";
    	string password = "xxx";
    
    	var securePassword = new SecureString();
    	foreach (char c in password.ToCharArray()) securePassword.AppendChar(c);
    	var credential = new SharePointOnlineCredentials(userName, securePassword);
    	GetAllSubWebs(siteUrl, userName, securePassword);
    	Console.WriteLine("Sub Site Count:"+subSiteCount+" Group Count:"+groupCount+" List Count:"+listCount);
    }
    private static void GetAllSubWebs(string path, string userName, SecureString password)
    {
    	// ClienContext - Get the context for the SharePoint Online Site               
    	using (var clientContext = new ClientContext(path))
    	{
    		// SharePoint Online Credentials    
    		clientContext.Credentials = new SharePointOnlineCredentials(userName, password);
    
    		// Get the SharePoint web  
    		Web web = clientContext.Web;
    		clientContext.Load(web, website => website.Webs, website => website.Title);
    
    		// Execute the query to the server  
    		clientContext.ExecuteQuery();
    	   
    		// Loop through all the webs  
    		foreach (Web subWeb in web.Webs)
    		{
    			// Check whether it is an app URL or not - If not then get into this block  
    			if (subWeb.Url.Contains(path))
    			{
    				string newpath = subWeb.Url;
    
    				GetAllSubWebs(newpath, userName, password);
    
    				clientContext.Load(subWeb.SiteGroups);
    				clientContext.Load(subWeb.Lists);                        
    				clientContext.ExecuteQuery();
    				subSiteCount += 1;
    				groupCount += subWeb.SiteGroups.Count;
    				listCount += subWeb.Lists.Count;
    				//Console.WriteLine("GroupCount:" + subWeb.SiteGroups.Count);
    				//Console.WriteLine("ListCount:" + subWeb.Lists.Count);
    				//Console.WriteLine(subWeb.Title + "-------" + subWeb.Url);
    			}
    		}
    	}
    }
