    using (var sr = new StreamReader(readFile))
    using (var sw = StreamWriter(writeFile))
    using (var sw2 = condition ? new StreamReader(writeFile2) : null)
    {
        var line = sr.ReadLine();
        sw.WriteLine(line);
        sw2?.WriteLine(line);
    }
