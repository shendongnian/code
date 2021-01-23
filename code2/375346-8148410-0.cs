    // This assumes myList has 20,000 entries
    // if .Where returned a new list we'd potentially double our memory!
    var largeStrings = myList.Where(ss => ss.Length > 100);
    foreach (var item in largeStrings)
    {
        someContainer.Add(item);
    }
    // or if we supported an IEnumerable<T>
    someContainer.AddRange(myList.Where(ss => ss.Length > 100));
