            public void SilentPrint(string filePath, string printerIPAddress)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            var client = new TcpClient(printerIPAddress, 9100);//9100 is the default print port for raw data
            using (var stream = client.GetStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
        }
