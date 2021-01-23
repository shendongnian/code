    List<CharData> charDataList = new List<CharData>();
    
    for (int i = 0; i < rssItems.Count; i++)
    {
        CharData cd = new CharData();
        cd.CharacterName = rssItems[i].Attributes["name"].Value;
        cd.CharacterID = rssItems[i].Attributes["characterID"].Value;
        cd.CorporationID = rssItems[i].Attributes["corporationID"].Value;
        cd.CorporationName = rssItems[i].Attributes["corporationName"].Value;
        charDataList.Add(cd);
    }
   
