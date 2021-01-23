    List<MyClass> originalCollection = new List<MyClass>();
    List<MyClass> newStuff = new List<MyClass>();
    foreach (var item in newStuff)
    {
        int index = originalCollection.FindIndex(x => x.Name == item.Name && x.Description == item.Description);
        if (index < 0)
            continue;
        originalCollection[index] = item;
    }
