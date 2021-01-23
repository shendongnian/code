    using System.Linq;
    using Sitecore.Analytics;
    
    // won't be null if a campaign was triggered
    if (!Tracker.CurrentVisit.IsCampaignIdNull())
    {
        var campaign = Tracker.DataContext.Where(x => x.ID.Guid == Tracker.CurrentVisit.CampaignId).FirstOrDefault();
        
        if (campaign != null)
        {
            // do stuff with the campaign here
            var name = campaign.Title;
        }
    }
