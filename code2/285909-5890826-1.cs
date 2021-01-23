    var MyDictionary = new Dictionary<string, string>();
    
    for (int i = 0; i < Math.Max(MyList.Count, MyArray.Length); i++)
    {
        MyDictionary.Add(MyList[i], MyArray[i]);
    }
