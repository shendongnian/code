    var txtPath = System.IO.Path.Combine(dirPath, txtFileName);
    var txtLines = File.ReadAllLines(txtPath).ToList();
    var filesFound = from file in Directory.EnumerateFiles(dirPath, "*.DST", SearchOption.AllDirectories)
                     where txtLines.Contains(System.IO.Path.GetFileName(file))
                     select new
                     {
                         File = file,
                         Line = System.IO.Path.GetFileName(file)
                     };
    foreach (var line in filesFound)
        Console.WriteLine($"{line.Line}");
