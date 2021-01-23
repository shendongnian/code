        var readBuffer = new byte[1024];
        using (var memoryStream = new MemoryStream())
        {
            do
            {
                int numberOfBytesRead = networkStream.Read(readBuffer, 0, readBuffer.Length);
                memoryStream.Write(readBuffer, 0, numberOfBytesRead);
                if (!networkStream.DataAvailable)
                    System.Threading.Thread.Sleep(1); //Or 50 for non-believers ;)
            }
            while (networkStream.DataAvailable);
        }
