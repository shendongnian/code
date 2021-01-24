    using (var sr = new StreamReader(readFile))
    using (var sw = StreamWriter(writeFile))
    {
        var line = sr.ReadLine();
        sw.WriteLine(line);
        if (condition)
        {
            using (var sw2 = StreamWriter(writeFile2))
                sw2.WriteLine(line);
        }
    }
