c#
    using(var reader = new StreamReader(@"C:\document.csv"))
    {
        List<object> list = new List<object>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(';');
            list.Add(new {a = values[0], b = values[1]});
        }
    }
