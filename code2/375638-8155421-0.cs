    for(var i = 0; i < list.Count; ++i)
    {
        var item = list[i];
        for(var j = i+i; j < list.Count; ++j)
        {
            Compare(item, list[j]);
        }
    }
