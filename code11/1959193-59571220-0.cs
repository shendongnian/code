        TcpClient client = Listener.AcceptTcpClient();
        Stream s = client.GetStream();
        
        byte[] file_content = File.ReadAllBytes(file);
 
        StringBuilder header = new StringBuilder();
        
        header.Append("HTTP/1.1 200 OK\r\n");
        header.Append($"Content-Type: {mime_type}\r\n");
        header.Append($"Content-Length: {file_content .Length}\r\n\n");
        byte[] h = Encoding.ASCII.GetBytes(header.ToString());
        s.Write(content, 0, content.Length);
        s.Write(b, 0, b.Length);
        s.Flush();
        client.Close();
    
