    string fileName = "Myfile.txt";
    StreamReader sr = new StreamReader(fileName);
    string[] delimiter = new string[] { "\r\n" };
    while (!sr.EndOfStream)
    {
        string[] lines = sr.ReadLine().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        { 
            date = line.Substring(6, 8);
            // Do the other processing here.
        }
    }
