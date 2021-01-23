    foreach (var item in collection2.Take(20)) // grab replacement range
    {
        int index;
        if ((index = collection1.FindIndex(x => 
                                      x.Name == item.Name && 
                                      x.Description == item.Description)) > -1)
        {
            collection1[index] = item;
        }
    }
    collection1.AddRange(collection2.Skip(20)); // append the rest
