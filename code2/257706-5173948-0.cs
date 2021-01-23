        foreach (var item in campaigns)
        {
            var campaign = listCampaigns.FirstOrDefault(a => a.CampaignName == item.CampaignName && a.Term == item.Term);
            if (campaign == null)
            {
                //this doesn't exist
                listCampaigns.Add(item);
            }
            else
            {
                //this exists already
                campaign.TotalVisits += item.TotalVisits;
                List<Conversion> listConversions = item.Conversions.ToList();
                listConversions.AddRange(campaign.Conversions.ToList());
                campaign.Conversions = listConversions.ToArray();
            }
        }
