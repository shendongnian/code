    StreamReader sr = new StreamReader(@"path_to_log");
    
    int lineNum = 1;
    const int searchingLineNum = 10;
    string line = string.Empty;
    
    while (sr.Peek() != -1)
    {
        line = sr.ReadLine();
    
        if (lineNum == searchingLineNum)
        {
            break;
        }
        lineNum++;
    }
    Console.WriteLine(line); // do what you want with this line (parse using Regex)
