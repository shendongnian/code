    list<ListData> theList =(from item in dt.AsEnumerable()
                             Select new ListData()
                                  {
                                     Id= (int)item["ID"],
                                     Grade = (string)item["GRADE"],
                                     PhoneNo = (string)item["PHONE"]
                                  }
                            ).ToList()
