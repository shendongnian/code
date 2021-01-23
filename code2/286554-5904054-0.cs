    List<string> lines1 = new List<string>();
    string path1 = @"C:\Development\test1.txt";
    for (int i = 0; i < 20; i++)
        lines1.Add("Test " + i);
    
    TextWriter textWriter = new StreamWriter(File.Create(path1));
    foreach(string line in lines1)
        textWriter.WriteLine(line);
    textWriter.Close();
