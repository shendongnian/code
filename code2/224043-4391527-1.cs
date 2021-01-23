    using (SPSite oSPsite = new SPSite("yourSiteUrlHere"))
    {
    	SPWebCollection siteWebs = oSPsite.AllWebs;
    	foreach (SPWeb web in siteWebs)
    	{
			try
			{				
				SPList list = null;
				try
				{
					list = web.Lists["PublishingImages"];
				}
				catch {}
				
				if (list != null)
				{
					// todo: update list properties here
					list.Update();
				}
			}
			finally
			{
				if(web != null)
					web.Dispose();
			}
    	}  
    }
