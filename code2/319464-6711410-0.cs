    using (FileStream fs = new FileStream("C:\\temp\\fFile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
    {
        StreamReader r = new StreamReader(fs);
        string t = r.ReadLine();
                
        Console.WriteLine(t);
        StreamWriter w = new StreamWriter(fs);
        w.WriteLine("string");
        w.Close();
        r.Close();
        fs.Close();
    }
