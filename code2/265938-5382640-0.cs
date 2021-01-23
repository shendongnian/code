     string s = File.ReadAllText(path);
        s = s.Replace("<Varients>", "");
        s = s.Replace("</Varients>", "");
    
        using (FileStream stream = new FileStream(path, FileMode.Create))
        using (TextWriter writer = new StreamWriter(stream))
        {
            writer.WriteLine("");
            writer.WriteLine(s);
        }
