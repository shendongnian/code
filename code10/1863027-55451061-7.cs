    public Static List<List<InventoryItem>> ToSwappedLists(this List<List<InventoryItem>> source)
    {
        // TODO: check for null source
        // TODO: check if all inner lists have same size
        int innerListSize = ..
        List<List<InventoryItem> result = new List<List<InventoryItem>>(innerListSize));
        for (int y = 0; y<innerListsize; ++y)
        {
            var swappedList = this.Source.Select(x => source[x][y]).ToList();
            result.Add(swappedList);
        }
        return result;
    }
           
