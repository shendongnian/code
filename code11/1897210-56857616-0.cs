    List<MarketData> marketDataList = new List<MarketData>();
    List<Category> businessList = new List<Category>();
    // this a one liner formatted on many line for visibility reasons
    Enumerable.Range(0, marketDataList.Count()) // generate a collection from 0 to Count
                      .ToList() // as a list
                      .ForEach(i => marketDataList[i].Business = businessList[i]); // for each index assign the value
