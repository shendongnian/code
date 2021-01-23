                else 
                {
                    //Add new label because CONTACT_LIST_ID Exists 
                    ContactList contactList = myContactDictionary[id];
                    string name = dr["LABEL_NAME"].ToString();
                    var label = contactList.Labels.Where(l => l.Name == name).FirstOrDefault();
                    if( label != null )
                        label.Count += Convert.ToInt32(dr["LABEL_COUNT"]);
                    else
                    {
                        contactList.Labels.Add(
                            new Label()
                            {
                                Name = dr["LABEL_NAME"].ToString(), 
                                Count = Convert.ToInt32(dr["LABEL_COUNT"])                                         
                            }
                        );
                    }
