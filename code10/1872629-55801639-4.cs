    Public IEnumerable<YourObjectType> FindDuplicates(IEnumerable<YourObjectType> myList, int maxDupes)
    {
        var listOfDuplicates = new IEnumerable<YourObjectType>();
        foreach (var a in myList)
        {
            foreach (var b in myListb)
            {
                if (a.multival == b.multival && a.name != b.name)
                    listOfDuplicates.Add(a);
                if (listOfDuplicates.length == maxDupes)
                    return listOfDuplicates;
            }
        }
        return listOfDuplicates;
    }
