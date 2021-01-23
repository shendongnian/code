    using (FileStream fs = File.OpenRead("D:\\06.Total Eclipse Of The Moon.mp3"))
    {
        byte[] buffer = new byte[1024];
        int bytesRead;
        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
        {
            sck.Client.Send(buffer, 0, bytesRead);
            // Do you really need this?
            Thread.Sleep(30);
        }
    }
