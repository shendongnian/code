    string filepath = @"C:\whatever.txt";
    using (StreamReader rdr = new StreamReader(filepath))
    {
        rdr.ReadLine();  // ignore 1st line
        rdr.ReadLine();  // ignore 2nd line
        string fileContents = "";
        while (true)
        {
            string line = rdr.ReadLine();
            if (rdr.EndOfStream)
                break;  // finish without processing last line
            fileContents += line + @"\r\n";
        }
        Console.WriteLine(fileContents);
    }
