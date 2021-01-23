    List<byte> allBytes = new List<byte>(MAX_TCP_DATA);
    int i;
    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
    {
        allBytes.AddRange( allBytes.Take(i) );
    }
    Console.WriteLine(allBytes.Count);
    string data = System.Text.Encoding.UTF8.GetString(allBytes.ToArray());
