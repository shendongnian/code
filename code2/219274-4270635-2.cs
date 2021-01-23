    for (int i = 0; i < filePaths.Length; i++)
    {
        bool isInList = false;
        foreach (string fileName in usedFileNames)
        {
            if (fileName.Equals(filePaths[i].Name))
            {
                isInList = true;
                break;
            }
            else
                isInList = false;
        }
        if (isInList == false)
        {
            Console.WriteLine("Not in list! #{0}", x);
            usedFileNames.Add(filePaths[i].Name);
        }
    }
