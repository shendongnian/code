    string completeLine = "";
    for(int i = 0 ; i < numCols ; i++)
    {
        completeLine += sqlDReader.GetValue(0).ToString();
        if (i < numCols - 1)
            completeLine += " ";
    }
    Console.WriteLine (completeLine);
