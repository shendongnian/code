    int collectionSize = 10000;
    
    //populate array
    _array = new int[collectionSize];
    
    for (int i = 0; i < collectionSize; i++)
    {
       _array[i] = i;
    }
    
    _dictionary = new Dictionary<int, int>();
    for (int i = 0; i < collectionSize; i++)
    {
       _dictionary.Add(i, i);
    
    }
