    // Loose-Type
    Hashtable hashTable = new Hashtable();
    hashTable.Add("key", "value");
    hashTable.Add("int value", 2);
    // ...
    foreach (DictionaryEntry dictionaryEntry in hashTable) {
        Console.WriteLine("{0} -> {1}", dictionaryEntry.Key, dictionaryEntry.Value);
    }
    // Strong-Type
    Dictionary<string, int> intMap = new Dictionary<string, int>();
    intMap.Add("One", 1);
    intMap.Add("Two", 2);
    // ..
    foreach (KeyValuePair<string, int> keyValue in intMap) {
        Console.WriteLine("{0} -> {1}", keyValue.Key, keyValue.Value);
    }
