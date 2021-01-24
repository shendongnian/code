     IEnumerable<Town> orderItemCollection;
            public IEnumerable<Town> OrderItemCollection
            {
                get
                {
                    if (orderItemCollection == null)
                        orderItemCollection = GetTowns();
                    return orderItemCollection;
                }
            }
    
            public IEnumerable<Town> GetTowns()
            {
                // Changing the database table items as ObservableCollection
                var table = (from i in database.Table<Town>() select i);
                ObservableCollection<Town> TownList = new ObservableCollection<Town>();
                foreach (var town in table)
                {
                    TownList.Add(new Town()
                    {
                        ID = town.ID,
                        TownName = town.TownName,
                        Temp = town.Temp,
                        searchTime = town.searchTime
                    });
                }
                return TownList;
            }
