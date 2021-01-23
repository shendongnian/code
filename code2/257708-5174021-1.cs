    List<Campaign> listCampaigns = new List<Campaign>();
    foreach (var g in campaigns.GroupBy(c => new { c.CampaignName, c.Term }))
    {
        var campaign = g.First();
        campaign.TotalVisits = g.Sum(x => x.TotalVisits);
        campaign.Conversions = g.SelectMany(c => c.Conversions).ToArray();
        listCampaigns.Add(campaign);
    }
