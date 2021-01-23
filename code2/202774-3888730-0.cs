    var filteredList = mainList.Select(m => new MainClass
                                { 
                                   Name = m.Name;
                                   MainAddress = m.MainAddress;
                                   ExtraInfo = m.ExtraInfo
                                                .Where(subClass => subClass.City == "New York")
                                                .ToList()
                                })
                              .ToList();
