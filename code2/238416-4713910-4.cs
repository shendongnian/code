        Dictionary<int, ContactList> myContactDictionary = new Dictionary<int, ContactList>();
        using (DB2DataReader dr = command.ExecuteReader())
        {
	
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["CONTACT_LIST_ID"]);
                if (!myContactDictionary.ContainsKey(id))
                {
                    ContactList contactList = new ContactList();
                    contactList.ContactListID = id;
                    contactList.ContactListName = dr["CONTACT_LIST_NAME"].ToString();
                    contactList.Labels = new ObservableCollection<Label>() 
                    { 
                        new Label() 
                        { 
                            Name = dr["LABEL_NAME"].ToString(), 
                            Count = Convert.ToInt32(dr["LABEL_COUNT"]) 
                        } 
                    };
                    myContactDictionary.Add(id, contactList);
                }
                else 
                {
                    //Add new label because CONTACT_LIST_ID Exists 
                    ContactList contactList = myContactDictionary[id];
                    contactList.Labels.Add(
                        new Label()
                            {
                                Name = dr["LABEL_NAME"].ToString(), 
                                Count = Convert.ToInt32(dr["LABEL_COUNT"])                                         
                            }
                        );
                }
            }
        }
