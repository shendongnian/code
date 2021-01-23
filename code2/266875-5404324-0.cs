    File.WriteAllText("test.txt", "1234\n56789");
    
    long position = -1;
    
    using (var sr = new myStreamReader("test.txt"))
    {
        Console.WriteLine(sr.ReadLine());
    
        position = sr.BytesRead;
    }
    
    Console.WriteLine("Wait");
    
    using (var sr = new myStreamReader("test.txt"))
    {
        sr.BaseStream.Seek(position, SeekOrigin.Begin);
        Console.WriteLine(sr.ReadToEnd());
    }
