    string filepath = @"C:\whatever.txt";
    using (StreamReader rdr = new StreamReader(filepath))
    {
        rdr.ReadLine();  // ignore 1st line
        rdr.ReadLine();  // ignore 2nd line
        while (true)
        {
            string line = rdr.ReadLine();
            if (rdr.EndOfStream)
                break;  // finish without processing last line
            ProcessLine(line);
        }
    }
