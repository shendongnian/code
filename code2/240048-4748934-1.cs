    else
    {
        bool flagAggLabelFound = false;
        ContactList contactList = myContactDictionary[id];
    
        foreach(AggregateLabel aggLabel in contactList.AggLabels)
        {
            if(aggLabel.Name == dr["LABEL_NAME"].ToString())
            {
                aggLabel.Count += Convert.ToInt32(dr["LABEL_COUNT"]);
                flagAggLabelFound = true;
                break;
            }
        }
    
        if (!flagAggLabelFound)
        {
            contactList.AggLabels.Add(
                            new AggregatedLabel()
                            {
                                Name = dr["LABEL_NAME"].ToString(),
                                Count = Convert.ToInt32(dr["LABEL_COUNT"])
    
                            }
            );
        }
    }
