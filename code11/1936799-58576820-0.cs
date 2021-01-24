    List<string> cellsList = new List<string>();
    cellsList.AddRange(myString.Split('\t'));
    string lineString = "";
    List<string> linesList = new List<string>();
    for (int i = 0; i < cellsList.Count; i++)
    {
        lineString += cellsList[i];
        if((i + 1)%4 == 0)
        {
           linesList.Add(lineString);
           lineString = "";
        }
    }
