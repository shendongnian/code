    var file = @"input.txt";
    var output = @"output.txt";
    var line = string.Empty;
    using (var sr = new StreamReader(file))
    {
        using (var sw = new StreamWriter(output))
        {
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line.Length < 25 && Char.IsDigit(line, 0))
                {
                    var line2 = sr.ReadLine();
                    line += line2;
                }
                sw.WriteLine(line);
            }
        }
    }
