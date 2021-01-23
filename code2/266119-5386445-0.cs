    int i = 123456;
    Int64 j = 123456;
    byte[] bytesi = BitConverter.GetBytes(i);
    byte[] bytesj = BitConverter.GetBytes(j);
    Console.WriteLine(bytesi.Length);
    Console.WriteLine(bytesj.Length);
