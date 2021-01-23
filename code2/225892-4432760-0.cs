    string input= "1,2,3,11,33";
    string[] split = string.Split(input);
    List<string> outputList = new List<string>();
    foreach(var s in split)
    {
        outputList.Add(s.PadLeft(2, '0'));
    }
    
    string output = string.Join(outputList.ToArray(), ',');
