    public static class DataStub
    {
            public static DataItems TestDataItems
            {
                get
                {
                    var dataItems = new DataItems();
                    dataItems.Data = new List<int>(){1,5,9,6,8};
                    dataItems.HighlightedIndex = 2;
    
                    return dataItems;
                }
            }
    }
