    using (var s = File.Create("test2.txt"))
    {
        s.WriteByte(32);
        using (var sw = new StreamWriter(s, Encoding.UTF8))
        {
            sw.WriteLine("hello, world");
        }
    }
