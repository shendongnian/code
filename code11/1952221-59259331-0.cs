    // Listen for the connection
    public async Task Listen()
    {
    	// ...
    
    	// Wait for some data (the client won't be sending any at this point)
    	byte[] msgBuf = new byte[100];
    	var lengthRead = await client.GetStream().ReadAsync(msgBuf, 0, 100);
    	if (lengthRead == 0)
    	{
    		// A graceful shutdown has occurred. The socket can now be disposed
    		// by "TcpClient.Close()"
    		client.Close();
    	}
    }
    
    // I will click this button to close the connection before the above call to `ReadAsync` receives any data
    private void button1_Click_1(object sender, EventArgs e)
    {
    	// This causes ReadAsync() to return 0 after which the socket can be disposed
    	client.Client.Shutdown(SocketShutdown.Both);
    }
