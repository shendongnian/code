    using (StreamReader sr = new StreamReader(@"\\t.txt"))
    {
        char[] c = new char[20];  // Invoice number string 
        sr.BaseStream.Position = 395;
        sr.Read(c, 0, c.Length); 
    }
