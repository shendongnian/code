    new Thread(() => {
        using (TcpClient client = new TcpClient(address, port))
        using (StreamWriter writer = new StreamWriter(client.GetStream()) {AutoFlush = true}) {
            writer.BaseStream.WriteByte((byte) ClientRequest.Register);
            writer.WriteLine(usernameInputField.text);
            writer.WriteLine(passwordInputField.text);
    
            ...
        }
    }).Start();
