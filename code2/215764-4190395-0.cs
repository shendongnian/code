    // assuming dict is your original dictionary
    var copy = new SortedDictionary<int, SortedDictionary<int, VolumeInfoItem>>();
    foreach(var subDict in dict)
    {
        var subCopy = new SortedDictionary<int, SortedDictionary<int, VolumeInfoItem>>();
        foreach(var data in subDict.Value)
        {
            var item = new VolumeInfoItem
                       {
                           up = data.Value.up,
                           down = data.Value.down,
                           neutral = data.Value.neutral,
                           dailyBars = data.Value.dailyBars
                       };
            subCopy.Add(data.Key, item);
        } 
        copy.Add(subDict.Key, subCopy);
    }
   
