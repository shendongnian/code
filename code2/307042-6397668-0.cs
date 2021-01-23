    using (var source = new StreamReader("c:\\test.txt"))
    using (var destination = File.AppendText("c:\\test2.txt"))
    {
        var line = source.ReadLine();
        destination.WriteLine(line);
    }
