    List<Campaign> listCampaigns = new List<Campaign>();
        foreach (var item in campaigns)
        {
            if (!listCampaigns.Any(a => a.CampaignName == item.CampaignName && a.Term == item.Term))
            {
                //this doesn't exist
                listCampaigns.Add(item);
            }
            else
            {
                //this exists already
                var campaign = listCampaigns.First(a => a.CampaignName == item.CampaignName && a.Term == item.Term);
                campaign.TotalVisits += item.TotalVisits;
                //Reduces the number of collection copies created per iteration from 3 to 1
                campaign.Conversions = campaignConversions.Concat(item.Conversions).ToArray();
            }
        }
