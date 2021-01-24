    var files = from file in Directory.EnumerateFiles(path, "*.TXT", SearchOption.AllDirectories)
                from line in File.ReadLines(file)
                where !line.Contains(System.IO.Path.GetFileName(file))  //note the exclamation mark, this is how you filter
                select new
                {
                    File = file,
                    Line = line
                };
    foreach (var line in files)
        Console.WriteLine($"{line.Line}");
