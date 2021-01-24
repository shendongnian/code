     int[] xs = { 1, 2, 3 };
     Span<int> xss = xs;
     Span<byte> bss = MemoryMarshal.Cast<int, byte>(xss);
     using (var writer = new BinaryWriter(File.Open("test.bin", FileMode.Create)))
     {
         writer.Write(bss);
     }
