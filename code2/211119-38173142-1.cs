        using (var stream = File.OpenRead("Foo.txt"))
        using (var reader = LineReader.Create(stream))
        {
            string line;
            while (reader.TryReadLine(out line))
            {
                Console.WriteLine(line);
            }
        }
