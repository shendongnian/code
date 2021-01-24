     int[] values = { 1, 2, 3 };
     using (var writer = new BinaryWriter(File.Open(path, FileMode.Create)))
     {
         Span<byte> bytes = MemoryMarshal.Cast<int, byte>(values.AsSpan());
         writer.Write(bytes);
     }
