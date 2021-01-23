    contactList.AggLabels = new Dictionary<string, int>();
...
    else
    {
        ContactList contactList = myContactDictionary[id];
        
        if (contactList.AggLabels.ContainsKey(dr["LABEL_NAME"].ToString()))
        {
            contactList.AggLabels[dr["LABEL_NAME"].ToString()] += Convert.ToInt32(dr["LABEL_COUNT"]);
        }
        else
        {
            contactList.AggLabels.Add(dr["LABEL_NAME"].ToString(), Convert.ToInt32(dr["LABEL_COUNT"]));
        }
    }
