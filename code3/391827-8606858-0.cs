    string content = String.Empty;
    
    using(var sr = new StreamReader(fs, Encoding.Unicode))
    {
         content = sr.ReadToEnd();
    }
    
    File.WriteAllText(outputPath, content, Encoding.UTF8);
