    FileStream fs = new FileStream("C:\\test.txt", 
                            FileMode.OpenOrCreate, 
                            FileAccess.ReadWrite, 
                            FileShare.ReadWrite);
    using (StreamReader r = new StreamReader(fs))
    {
        string t = r.ReadLine();
        r.Close();
        Console.WriteLine(t);
    }
    fs = new FileStream("C:\\test.txt", 
                FileMode.OpenOrCreate, 
                FileAccess.ReadWrite, 
                FileShare.ReadWrite);
    using (StreamWriter w = new StreamWriter(fs))
    {
        w.WriteLine("string");
        w.Flush();
        w.Close();
    }
    fs.Close();
