    TreeDictionary<int,int> dictionary = new TreeDictionary<int,int>();
    dictionary.Add(1,33);
    dictionary.Add(2,20);
    dictionary.Add(4,35);
    // applied to the dictionary itself, returns KeyValuePair<int,int>
    var previousValue = dictionary.Predecessor(4);
    Assert.Equals(previousValue.Key, 2);
    Assert.Equals(previousValue.Value, 20);
    // applied to the keys of the dictionary, returns key only
    var previousKey = dictionary.Keys.Predecessor(4);
    Assert.Equals(previousKey, 2);
    // it is also possible to specify keys not in the dictionary
    previousKey = dictionary.Keys.Predecessor(3);
    Assert.Equals(previousKey, 2);
