    ContactList contactList = myContactDictionary[id];
    AggregateLabel existing = contactList.AggLabels.FirstOrDefault(
                                  l => l.Name == dr["LABEL_NAME"].ToString()
                              );
    if (existing == null) { contactList.AggLabels.Add(
                                new AggregatedLabel() {
                                    Name = dr["LABEL_NAME"].ToString(),
                                    Count = Convert.ToInt32(dr["LABEL_COUNT"])
                                }
                            );
                          }
    else { existing.Count += Convert.ToInt32(dr["LABEL_COUNT"]); }
