        var stream = File.OpenRead("Foo.txt");
        using (var reader = LineReader.Create(ref stream))
        {
            string line;
            while (reader.TryReadLine(out line))
            {
                Console.WriteLine(line);
            }
        }
