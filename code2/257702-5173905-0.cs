    var dict=new Dictionary<Tuple<string,Term>,Campaign>();
    var currentKey=new Tuple<string,Term>(item.CampaignName, item.Term == item.Term);
    Campaign existingCampaign;
    if (dict.TryGetValue(currentKey,out existingCampaign))
    {
    //already exists
    }
    else
    {
    //new
    }
