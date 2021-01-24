    TcpListener server = new TcpListener(IPAddress.Any,12345);
    using(TcpClient client = await server.AcceptTcpClientAsync()) 
    {
        byte[] imagebyte = File.ReadAllBytes("ImageCaptured.temp");
        using(NetworkStream writer = client.GetStream())
        {
            byte[] imgLength = 
            writer.Write(imagebyte.Length)
            writer.Write(imagebyte, 0, imagebyte.Length);
        }
        File.Delete("ImageCaptured.temp");
    }
