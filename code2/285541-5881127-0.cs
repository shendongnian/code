    TcpClient client = new TcpClient();
    client.Connect(IPAddress.Parse("someip"), someport);
    NetworkStream stream = client.GetStream();
    byte[] myWriteBuffer = Encoding.ASCII.GetBytes("some JSON");
    stream.Write(myWriteBuffer, 0, myWriteBuffer.Length);
    byte[] readBuffer = stream.GetBuffer();
    Console.WriteLine(Encoding.ASCII.GetString(bytes));
