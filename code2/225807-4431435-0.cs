    System.Collections.Generic.List<string> fileToWrite = new List<string>();
    string[] file1 = System.IO.File.ReadAllLines(filePath);
    string[] file2 = System.IO.File.ReadAllLines(anotherFilePath);
    string[] fileWithTrueFalse = System.IO.File.ReadAllLines(fileWithTrueFalsePath);
    for (int i = 0; i < file1.Length; i++)
    {
        if (fileWithTrueFalse[i].Substring(fileWithTrueFalse[i].IndexOf('=')) == "true")
            fileToWrite.Add(file2[i]);
        else
            fileToWrite.Add(file1[i]);
    }
    System.IO.File.WriteAllLines(fileToWritePath, fileToWrite.ToArray());
