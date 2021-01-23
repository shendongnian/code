    var dictCampaigns = new Dictionary<Key, Campaign>();
    foreach (var item in campaigns)
    {
        Campaign found;
        var key = new Key(item);
        if(!dictCampaigns.TryGetValue(key,out found))
        {
            dictCampaigns.Add(key, item);
        }
        else
        {
            found.TotalVisits += item.TotalVisits;
            found.Conversions = (item.Conversions.Concat(found.Conversions)).ToArray();
        }
    }
