    var siteUrl = "http://sp2013";
    var listTitle = "customlist";
    using (SPSite site = new SPSite(siteUrl))
    {
    	using (SPWeb web = site.OpenWeb())
    	{
    		SPList list = web.Lists[listTitle];
    		foreach (SPField field in list.Fields)
    		{
    			Console.WriteLine("Name:"+field.Title+" | InternalName:"+field.InternalName);
    		}
    	}
    }
    Console.ReadKey();
