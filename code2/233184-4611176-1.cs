    var listToBeAdded = a;
    foreach (var item in someList)
    {
        if (listToBeAdded == a && CheckCondition(item))
            listToBeAdded = b;
        listToBeAdded.Add(item);
    }
