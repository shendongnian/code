    public static List<SortedItem> GetSortedItems()
    {
        List<Item> items = GetItems();
    
        List<SortedItem> sortedItems = new List<SortedItem>()
        {
            new SortedItem(items.Where(x => x.lvl == 50).ToList())
            {
                Header = "50"
            },
            new SortedItem(items.Where(x => x.lvl == 55).ToList())
            {
                Header = "55"
            },
            new SortedItem(items.Where(x => x.lvl == 60).ToList())
            {
                Header = "60"
            },
            new SortedItem(items.Where(x => x.lvl == 65).ToList())
            {
                Header = "65"
            },
            new SortedItem(items.Where(x => x.lvl == 70).ToList())
            {
                Header = "70"
            }
        };
    
        return sortedItems;
    }
