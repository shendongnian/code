    var listOfExistingNames = new List<string> { "MyName", "MyName1", "MyName3" };
    var listOfDeletedNames = new List<string> { "MyName2", "MyName5" };
    int counter = 0;
    string baseToFindFreePlace = "MyName";
    string newName = baseToFindFreePlace;
    var allNames = listOfExistingNames.Concat(listOfDeletedNames);
    while (allNames.Contains(newName))
    {
        counter++;
        newName = baseToFindFreePlace + counter;
    }
    listOfExistingNames.Add(newName);
