    var files = from file in Directory.EnumerateFiles(@"c:\",
                    "*.txt", SearchOption.AllDirectories)
                from line in File.ReadLines(file)
                where line.Contains("Microsoft")
                select new
                {
                    File = file,
                    Line = line
                };
    
    foreach (var f in files)
    {
        Console.WriteLine("{0}\t{1}", f.File, f.Line);
    }
