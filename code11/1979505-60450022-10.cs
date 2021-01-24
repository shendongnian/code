    var jsonString = File.ReadAllText(jsonFile);
    var result = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
    var lstNames = new List<string>();
    PushNamesToList(lstNames, result);
    foreach(var item in lstNames)
    {
        Console.WriteLine(item);
    }
