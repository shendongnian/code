    public static void SendEmail(SPWeb web, string to, string subject, string body)
    {
    	var siteId = Web.Site.ID;
    
    	System.Threading.ThreadPool.QueueUserWorkItem(o =>
    	{
    		using (var site = new SPSite(siteId))
    		using (var myWeb = site.OpenWeb())
    		{
    			SPUtility.SendEmail(myWeb, false, false, to, subject, body);
    		}
    	});
    }
