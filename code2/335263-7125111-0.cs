If you look at this example take from [MSDN][1] we see that they are using Encoding.Unicode to convert the Text, you can do a similar thing when reading just using [UTF8Encoding][2]
    using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("ExampleMemoryMap", 1000))
    {
      using (MemoryMappedViewStream stream = mmf.CreateViewStream())
      {
        byte[] temp = Encoding.Unicode.GetBytes("This string is from C#");
        stream.WriteByte((byte)temp.Length);
        stream.Write(temp, 0, temp.Length);
        // Ensure the string is null-padded
        stream.WriteByte(0);
        stream.WriteByte(0);
        Console.Write("Press any key to exit . . . ");
        Console.ReadKey(true);
      }
    }
