    Dictionary<int, List<Roll>> myDict = new Dictionary<int, List<Roll>>();
    if (myDict.ContainsKey(ID))
    {               
        myDict[ID].AddRange(_WorkRolls);
        myDict[ID].AddRange(_UsedRolls);
    }
    else
    {
        myDict.Add(ID, _OldRolls);
    }
