    var stream = new MemoryStream();
    using(var writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
    {
    	writer.Write('a');
    }
    Console.WriteLine(stream.ToArray()
        .Select(b => b.ToString("X2"))
        .Aggregate((i, a) => i + " " + a)
        );
