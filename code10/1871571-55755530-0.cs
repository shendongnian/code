    using(TcpClient client = new TcpClient())
    {
        client.Connect(IPAddress.Parse("123.456.789.123"), 12345);
        using (var clientStream = client.GetStream()) 
        {
            int imageLength = reader.ReadInt32();
            byte[] imagebyte = new byte[imageLength);
            int readBytes = 0;
            while (readBytes < imageLength)
            {
                 int nextReadSize = Math.Min(client.Available, imageLength - readBytes);
                 readBytes += await clientStream.ReadAsync(imagebyte, readBytes, nextReadSize);
            }
        }
        File.WriteAllBytes("Screenshot.png",ImageByte);
    }
