    ReadOnlyCollection<int> roc = new ReadOnlyCollection<int>(new[] { 1, 2, 3 });
    // Invalid
    // roc.Add(10);
    ICollection<int> collection = roc;
    collection.Add(10); // Valid at compile time, but will throw an exception
