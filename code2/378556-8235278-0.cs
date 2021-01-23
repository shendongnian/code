    if(!Tracker.CurrentVisit.IsCampaignIdNull())
    {
        var campaignDataTable = new SharedDataSet.CampaignsDataTable();
        var data = campaignDataTable.FindByCampaignId(Tracker.CurrentVisit.CampaignId); 
        Response.Write("Campaign Name:" + data.CampaignName);
        Response.Write("Id:" + Tracker.CurrentVisit.CampaignId);    
    }
    else
    {
        Response.Write("No campaign found!");
    } 
