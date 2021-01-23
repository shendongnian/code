    clientStream = tcpClient.GetStream(); // Not in foreach loop !!
    // ...
    System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead)); 
    foreach(TcpClient client in clients)
    {
        // Send message to client
        st = client.GetStream();
        st.Write(message, 0, message.Length);
    }
