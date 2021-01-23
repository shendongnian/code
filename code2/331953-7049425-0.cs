    var bytes = Encoding.ASCII.GetBytes("String");
    Stream stream = new MemoryStream(bytes);
    Console.WriteLine((char)stream.ReadByte()); //S
    Console.WriteLine((char)stream.ReadByte()); //t
    stream.Position -= 1;
    Console.WriteLine((char)stream.ReadByte()); //t
    Console.WriteLine((char)stream.ReadByte()); //r
    Console.WriteLine((char)stream.ReadByte()); //i
    Console.WriteLine((char)stream.ReadByte()); //n
    Console.WriteLine((char)stream.ReadByte()); //g
