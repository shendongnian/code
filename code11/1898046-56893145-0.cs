    Dictionary<int, string> map = new Dictionary<int, string>();
    map.Add(256, "OI");
    map.Add(302, "OI");
    map.Add(303, "N2");
    map.Add(304, "N2.5");
    map.Add(400, "N2");
    // will contain the final results.
    Dictionary<int, string> results = new Dictionary<int, string>();
    // get map ordered
    var mapList = map.OrderBy(o => o.Key).ToList();
    // iterate until we have worked out each values
    while (mapList.Any())
    {
        // take first item
        var item = mapList[0];
        // kepp the index of found consecutive values                             
        var index = 0;
        // loop for each value
        for (int i = 1; i < mapList.Count; i++)
        {
            // if the value isn't 1 higher get out the loop
            if (mapList[i].Key != mapList[index].Key + 1)
            {
                break;
            }
            else
            {
                // value is more than 1 so keep going until we can't
                index++;
            }
        }
        // if we have found at least 2 consecutive numbers
        if (index > 0)
        {
            // add the first of the sequence
            results.Add(item.Key, item.Value);
            // add the rest of the sequence that was found
            for (int i = 0; i < index; i++)
            {
                results.Add(mapList[i + 1].Key, mapList[i + 1].Value);
            }
            // finally removed all items found plus the starting item (hence the + 1)
            mapList.RemoveRange(0, index + 1);
        }
        else
        {
            // no consecutive numbers found so just remove the item so we can loop and try the next one
            mapList.RemoveAt(0);
        }
    }
