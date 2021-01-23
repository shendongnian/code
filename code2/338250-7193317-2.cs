    List<int> toRemove = new List<int>();
    foreach (var elem in myList)
    {
        // Do some stuff
    
        // Check for removal
        if (needToRemoveAnElement)
        {
            toRemove.Add(someElement);
        }
    }
    
    // Remove everything here
    myList.RemoveAll(x => toRemove.Contains(x));
