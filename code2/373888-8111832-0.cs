        TcpClient client = new TcpClient("localhost", 20345);
        NetworkStream stream = client.GetStream();
        while (true)
        {
            string message = Console.ReadLine();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);  
            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);
        }
        client.Close();
