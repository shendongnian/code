    try
    {
        using (var reader = File.OpenText(@"c:\users\public\test.txt"))
        {
            char[] buffer = new char[10];
            reader.ReadBlock(buffer, index, buffer.Length);
             // Do something with buffer...
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine("Error reading from {0}. Message = {1}", path, e.Message);
    }
