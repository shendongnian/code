        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(';');
            var d = new Dictionary<string, object>(); // New dictionary for each line
            for (int i = 0; i < values.Length; i++)
            {
                d.Add(keys[i], values[i]);
            }
            l.Add(d);
        }
