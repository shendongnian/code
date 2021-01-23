    byte[] bytes = System.IO.File.ReadAllBytes(@"C:\yourfile.flv");
    BitArray bits = new BitArray(bytes);
                
    for (int counter = 0; counter < bits.Length; counter++)
    {
        Console.Write(bits[counter] ? "1" : "0");
        if ((counter + 1) % 8 == 0)
            Console.WriteLine();
    }
